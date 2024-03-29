﻿using NUnit.Framework;
using Utau.Elements;

namespace Utau.OverFlags.Domain.Commands.Flags
{
    internal class FlagsOverWriterCommandTest : FlagsCommandTest
    {
        [Test]
        public void Flagsの上書き()
        {
            UtauElement elm = EditedElement("Y10", CreateEditType("B5"));
            Assert.That(elm["Flags"], Is.EqualTo("B5"));
        }

        [Test]
        public void OverWriterのToStringのテスト()
        {
            Assert.That(CreateEditType("B5").ToString(), Is.EqualTo("「B5」で上書き"));
        }

        private FlagsCommand CreateEditType(string flag)
        {
            return new FlagsOverWriter(flag);
        }
    }
}