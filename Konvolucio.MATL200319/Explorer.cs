

namespace Konvolucio.MATL200319.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Devices;
    using System.IO;
   // using Events;

    public class Explorer
    {
        //public event EventHandler<IDevice> NewDeviceArrived;
        //public event EventHandler<IDevice> DeviceUpdated;
        public DateTime StartTimeSamp { get; set; }
        public DeviceCollection Devices;

        public Explorer()
        {
            Devices = new DeviceCollection();

            //TimerService.Instance.Tick += (s, e) =>
            //{
            //    Log();
            //};

        }

        public bool UpdateTask(CanMsg msg)
        {
            //if (CanDb.GetNodeTypeId(msg.ArbId) == CanDb.Instance.Nodes.FirstOrDefault(n => n.Name == NodeCollection.NODE_MCEL).NodeTypeId)
            //{
            //    byte node = CanDb.GetNodeAddress(msg.ArbId);
            //    byte msgId = CanDb.GetMsgId(msg.ArbId);

            //    if (Devices.FirstOrDefault(n => n.Address == node) is IDevice item)
            //    {
            //        item.Update(msgId, msg.Data);
            //        DeviceUpdated?.Invoke(this, item);
            //    }
            //    else
            //    {
            //        var newitem = new MCEL181123DeviceItem(node, msgId, msg.Data);
            //        Devices.Add(newitem);
            //        NewDeviceArrived?.Invoke(this, newitem);
            //    }
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return true;
        }
    }
}
