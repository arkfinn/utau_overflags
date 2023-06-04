using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utau.OverFlags.Domain.Commands.Connectors
{
    class SuffixConnectorTest
    {
        [Test]
        public void 前に追加()
        {
            SuffixConnector connector = new SuffixConnector("あ");
            Assert.That(connector.Connect("い"), Is.EqualTo("いあ"));
        }
    }
}
