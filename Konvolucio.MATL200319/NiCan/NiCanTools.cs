using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.MATL200319.NiCan
{
    public class NiCanTools
    {
        public static List<string> GetAdapters()
        {
            var adapaters = new List<string>();
            adapaters.AddRange( new string[]{ "CAN0", "CAN1"} );
            return adapaters;
        }

        public static string StatusToString(int status)
        {
            const uint msgBufSize = 1024;
            StringBuilder statusStr = new StringBuilder((int)msgBufSize);
            NiCan.ncStatusToString(status, msgBufSize, statusStr);
            return statusStr.ToString();
        }

    }
}
