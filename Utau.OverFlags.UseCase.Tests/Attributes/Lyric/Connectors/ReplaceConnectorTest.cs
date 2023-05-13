using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.Attributes.Lyric.Connectors
{
    class ReplaceConnectorTest
    {
        [Test]
        public void 置き換え()
        {
            ReplaceConnector connector = new ReplaceConnector("あ");
            Assert.That(connector.Connect("い"), Is.EqualTo("あ"));
        }
    }
}
