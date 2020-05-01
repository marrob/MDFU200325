namespace Konvolucio.MUDS150628.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class UintTest_Frimware
    {

        [Test]
        public void _0001_Create_File_With_Uint32_Numbers()
        {
            byte[] data = new byte[300];
            Assert.Fail();
            int ptr = 0;
            for (int i = 0; ptr < data.Length; i++)
            {
                Buffer.BlockCopy(BitConverter.GetBytes(i), 0, data, ptr, 4);
                ptr += 4;
            }

            string path = @"D:\@@@!ProjectS\KonvolucioApp\Konvolucio.MDFU200325\resources\BINARY_1234_300byte.bin";

            using (FileStream fs = new FileStream(path, FileMode.CreateNew))
            {
                fs.Write(data, 0, data.Length);
            }
        }

        [Test]
        public void _0002_Create_File_With0xFF()
        {
            byte[] data = new byte[500];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0xFF;
            }

            string path = @"D:\@@@!ProjectS\KonvolucioApp\Konvolucio.MDFU200325\resources\BINARY_FF_500byte.bin";

            using (FileStream fs = new FileStream(path, FileMode.CreateNew))
            {
                fs.Write(data, 0, data.Length);
            }
        }
    }
}
