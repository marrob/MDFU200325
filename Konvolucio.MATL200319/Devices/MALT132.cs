
namespace Konvolucio.MATL200319.Service.Devices
{
    using System;
    using System.ComponentModel;
    using Common;
    using System.Collections;
    using System.Linq;
    using System.Diagnostics;

    public class MCEL181123DeviceItem : IDevice, INotifyPropertyChanged
    {
        public byte Address { get; set; }

        public DateTime LastRxTimeStamp { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        public MCEL181123DeviceItem() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public MCEL181123DeviceItem(byte deviceAddress, byte msgId, byte[] data)
        {
            Address = deviceAddress;
            Update(msgId, data); 
        }

        public void Update(byte msgId, byte[] data)
        {
           
        }

        private void OnProppertyChanged(string propertyName)
        {
              PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
