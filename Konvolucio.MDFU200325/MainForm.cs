using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Konvolucio.MDFU200325
{

    public interface IMainForm
    {

        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;

        event EventHandler WriteEventHandler;
        event EventHandler FileBrowseEventHandler;

        string Text { get; set; }

        int PoregressValue { get; set; }

        byte Address { get; set; }

        string LabelStatus { get; set; }

        bool WriteEnabled { get; set; }

        //ToolStripItem[] MenuBar { set; }
        //ToolStripItem[] StatusBar { set; }
        //bool AlwaysOnTop { get; set; }


        //event KeyEventHandler KeyUp;
        //event HelpEventHandler HelpRequested; /*????*/

        //void CursorWait();
        //void CursorDefault();
    }

    public partial class MainForm : Form, IMainForm
    {

        public event EventHandler WriteEventHandler
        {
            add { buttonWrite.Click += value; }
            remove { buttonWrite.Click -= value; }
        }
        public event EventHandler FileBrowseEventHandler
        {
            add { buttonBrowse.Click += value; }
            remove { buttonBrowse.Click -= value; }
        }

        public int PoregressValue
        {
            get { return ProgressBar.Value; }
            set { ProgressBar.Value = value; }                   
        }

        public byte Address {
            get { return (byte)NumericUpDownAddress.Value; }
            set { NumericUpDownAddress.Value = value; }
        }

        public string LabelStatus {
            get { return labelStatus.Text; }
            set { labelStatus.Text = value; }
        }

        bool wrtieEnabled;
        public bool WriteEnabled
        {
            get { return wrtieEnabled; }
            set 
            {
                buttonWrite.Enabled = value;
                wrtieEnabled = value; 
            }
        }

        public MainForm() 
        {
            InitializeComponent();
        }
    }
}
