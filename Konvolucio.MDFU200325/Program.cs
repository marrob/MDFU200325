
namespace Konvolucio.MDFU200325
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading;
    using Properties;
    using System.Diagnostics;
    using Konvolucio.MUDS150628;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((MainForm)new App().MainForm);
        }
    }

    class App
    {
        public static SynchronizationContext SyncContext = null;

        public IMainForm MainForm { get; set; }

        NiCanInterface NiCanInterface;

        public App()
        {

            if (Settings.Default.ApplictionSettingsSaveCounter == 0)
            {
                Settings.Default.Upgrade();
                Settings.Default.ApplictionSettingsUpgradeCounter++;
            }
            Settings.Default.ApplictionSettingsSaveCounter++;
            Settings.Default.PropertyChanged += (s, e) =>
            {
                Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "(): " +
                    e.PropertyName + ", NewValue: " + Settings.Default[e.PropertyName]);
            };

            Settings.Default.SettingsLoaded += (s, e) =>
            {
                Debug.WriteLine("SettingsLoaded");
            };

            Settings.Default.SettingChanging += (s, e) =>
            {
                Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            };

            MainForm = new MainForm();
            MainForm.Text = AppConstants.SoftwareTitle;

            
            MainForm.FileBrowseEventHandler += ButtonBrowse_Click;
            MainForm.FormClosed += MainForm_FormClosed;
            MainForm.WriteEventHandler += ButtonWrite_Click;
            MainForm.Shown += MainForm_Shown;

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SyncContext = SynchronizationContext.Current;
        }

        private void ButtonWrite_Click(object sender, EventArgs e)
        {
            byte address = MainForm.Address;

            UInt32 txId = (UInt32)0x600 | address;
            UInt32 rxId = (UInt32)0x700 | address ;
            UInt32 baudRate = 250000;

            NiCanInterface = new NiCanInterface("CAN0", false, txId, rxId, baudRate);
            NiCanInterface.Connect();
            NiCanInterface.BusTerminationEnable = true;
            NiCanInterface.Open();


            MainForm.WriteEnabled = false;

            var network = new Iso15765NetwrorkLayer(NiCanInterface);
            network.ReadTimeoutMs = 1000;
            network.ParserLog = false;
            var dfu = new AppDfu(network);

            dfu.ProgressChange += (o, ev) =>
            {
                MainForm.PoregressValue= ev.ProgressPercentage;
                MainForm.LabelStatus = ev.UserState.ToString();
            };
            

            byte[] firmware =  Tools.OpenFile(Settings.Default.LastPath);
            dfu.Begin(firmware);

            Action syncCompleted = () =>{

            };

            dfu.Completed += (o, ev) =>
            {
                NiCanInterface.Close();
                MainForm.WriteEnabled = true;

                if (App.SyncContext != null)
                    App.SyncContext.Post((e1) => { syncCompleted(); }, null);

                if (ev.Result is Exception)
                    MessageBox.Show( (ev.Result as Exception).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        
            };


        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            

            Settings.Default.Save();
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            var ofd =  new OpenFileDialog();
            if (string.IsNullOrEmpty(Settings.Default.LastPath))
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                ofd.InitialDirectory = Settings.Default.LastPath;
            ofd.Filter = AppConstants.FileFilter;
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.LastPath = ofd.FileName;
            }
        }
    }
        
}
