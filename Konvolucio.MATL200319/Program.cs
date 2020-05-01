using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Konvolucio.MATL200319.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            new App();
        }
    }


    class App
    {
        public static System.Threading.SynchronizationContext SyncContext = null;

        TcpService _tcpService;

        public App()
        {
            /*** TcpService ***/
            _tcpService = new TcpService();
            _tcpService.ParserCallback = TcpServiceParser;
            _tcpService.Begin(null);
            _tcpService.Completed += TcpService_Completed;


            Configuration.Instance.Baudrate = 250000;
            Configuration.Instance.CanInterface = "CAN0";
        }


        /*** TcpService ***/
        private string TcpServiceParser(string line)
        {
            line = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ");
            var array = line.Trim().Split(' ');
            var addrStr = array[0].Trim();
            var command = array[1].Trim();

            byte address = 0;
            if (!addrStr.Contains("#"))
                return "Emulator address format is invalid. Use this: '#A1 MEAS:VOLT?' (-???)";

            if (!byte.TryParse(addrStr.Substring(1), out address))
                return "Data Type Error (-104)";

            {
                return "Hardware Missing (-241)";
            }

            return "UNKNOWN";
        }


        private void TcpService_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            AppLog.Instance.WirteLine(e.Error.Message);
        }


    }
}