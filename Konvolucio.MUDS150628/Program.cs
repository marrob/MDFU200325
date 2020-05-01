using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Konvolucio.MUDS150628
{
    class Program
    {

        static void Main(string[] args)
        {
            UInt32 txId = 0x603;
            UInt32 rxId = 0x703;
            UInt32 baudRate = 250000;
            var canLink = new NiCanInterface("CAN0", false, txId, rxId, baudRate);
            canLink.Connect();
            canLink.BusTerminationEnable = true;
            canLink.Open();

            var network = new Iso15765NetwrorkLayer(canLink);
            network.ParserLog = false;
            var dfu = new AppDfu(network);
            IoLog.Instance.FilePath = @"D:\io_log.txt";
            Console.WriteLine("LogPath:" +  IoLog.Instance.FilePath);
            try
            {
                
               byte[] temp;
                //                var path = @"D:\@@@!ProjectS\KonvolucioApp\Konvolucio.MDFU200325\resources\MALT132_V0603.bin";
                var path = @"D:\@@@!ProjectS\KonvolucioApp\MDFU200325\Resources\BINARY_FF_500byte.bin";
               temp = Tools.OpenFile(path);

                dfu.ProgressChange += (o, e) =>
                  {
                      Console.WriteLine(e.UserState);
                  };

                dfu.Begin(temp);

                Console.Read();
            }
            finally
            {
                Console.WriteLine("Complete");
                canLink.Close();
                canLink.Disconnect();

            }

        }
    }



}
