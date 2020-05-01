using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Konvolucio.MATL200319.Service
{
    public class Configuration
    {
        public string CanInterface { get; set; }
        public uint Baudrate { get; set; }
        public static Configuration Instance { get; } = new Configuration();



    }
}
