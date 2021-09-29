﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.Attributes.Lyric.Connectors
{
    class PrefixConnectorTest
    {
        [Test]
        public void 前に追加()
        {
            PrefixConnector connector = new PrefixConnector("あ");
            Assert.That(connector.Connect("い"), Is.EqualTo("あい"));
        }
    }
}
