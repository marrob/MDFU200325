
namespace Konvolucio.MATL200319.Service.Devices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.IO;


    public class DeviceCollection : BindingList<IDevice>
    {

        public static byte TpyeCode = 0x05;

        protected override void InsertItem(int index, IDevice item)
        {
            base.InsertItem(index, item);
        }

        public new void Remove(IDevice item)
        {
            base.Remove(item);
        }
    }
}
