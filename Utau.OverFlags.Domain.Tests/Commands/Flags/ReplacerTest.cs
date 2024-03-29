﻿using NUnit.Framework;
using Utau.Elements;

namespace Utau.OverFlags.Domain.Commands.Flags
{
    internal class ReplacerTest : FlagsCommandTest
    {
        [Test]
        public void Flagsの置き換え()
        {
            UtauElement elm = EditedElement("Y10B10", CreateEditType("B5"));
            Assert.That(elm["Flags"], Is.EqualTo("Y10B5"));
        }

        [Test]
        public void OverWriterのToStringのテスト()
        {
            Assert.That(CreateEditType("B5").ToString(), Is.EqualTo("「B5」で置換"));
        }

        private FlagsCommand CreateEditType(string flag)
        {
            return new FlagsReplacer(flag);
        }
    }
}