
namespace Konvolucio.MATL200319.Service.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public struct CanMsg
    {
        public long TimestampTick { get; set; }
        public UInt32 ArbId { get; set; }
        public byte IsRemote { get; set; }
        public byte[] Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arbId"></param>
        /// <param name="data"></param>
        public CanMsg(UInt32 arbId, byte[] data)
        {
            TimestampTick = 0;
            ArbId = arbId;
            IsRemote = 0;
            Data = data;
            if (data != null)
            {
                if (data.Length > 8)
                {
                    throw new ApplicationException("The CAN Message cant be longer than 8 byte.");
                }
            }
            else
            {
                throw new ApplicationException("The CAN data cannot be null.");
            }
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
            // If parameter cannot be cast to MctComponentItem return false.
            CanMsg p = (CanMsg)obj;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (p.ArbId == this.ArbId &&
                p.IsRemote == this.IsRemote)
            {
                if (p.Data == null ^ this.Data == null)
                    return false;
                else
                    if (p.Data == null && this.Data == null)
                    return true;
                else
                        if (p.Data.Length != this.Data.Length)
                    return false;
                else
                            if (p.Data.SequenceEqual(Data))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(CanMsg a, CanMsg b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(CanMsg a, CanMsg b)
        {
            return !(a == b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = string.Empty;

            if (TimestampTick != 0)
                str += new DateTime(TimestampTick).ToString("dd.MM.yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture) + " ";

            if ((ArbId & 0x20000000) == 0x20000000)
            { //ExtId
                str += string.Format("0x{0:X8}", TimestampTick) + " ";
                str += string.Format("0x{0:X8}*", ArbId & 0x1FFFFFFF) + " ";
                str += string.Format("0x{0:X2}", IsRemote) + " ";
                str += string.Format("0x{0:X2}", Data.Length) + " ";
            }
            else
            { //StdId
                str += string.Format("0x{0:X8}", TimestampTick) + " ";
                str += string.Format("0x{0:X8}", ArbId) + " ";
                str += string.Format("0x{0:X2}", IsRemote) + " ";
                str += string.Format("0x{0:X2}", Data.Length) + " ";
            }

            if (Data != null && Data.Length != 0)
            {
                for (int i = 0; i < Data.Length; i++)
                    str += string.Format("0x{0:X2}", Data[i]) + " ";
            }
            str = str.TrimEnd();
            return str;
        }

        public static CanMsg MessageStdA0
        {
            get
            {
                CanMsg msg = new CanMsg();
                msg.TimestampTick = 0x00000000;
                msg.ArbId = 0x000000A0;
                msg.IsRemote = 0x00; 
                msg.Data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, };
                return msg;
            }
        }
    }
}
