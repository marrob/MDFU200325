using System;

namespace Konvolucio.MUDS150628
{
    public interface IPhysicalLink
    {
        void Write(byte[] data);
        void Read(out byte[] data, int tiemoutMs);
    }
}
