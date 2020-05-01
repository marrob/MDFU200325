using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.MATL200319.Service.Devices
{
    using NUnit.Framework;
    using System.Diagnostics;
    using System.Text;
    using Common;

    [TestFixture]
    class UintTest
    {
        [Test]
        public void first()
        {
            var de = new Explorer();

            de.UpdateTask(new CanMsg(0x00000100, new byte[] { 0x00, 0x01 }));
            de.UpdateTask(new CanMsg(0x00000100, new byte[] { 0x00, 0x01 }));
        }
    }
}
