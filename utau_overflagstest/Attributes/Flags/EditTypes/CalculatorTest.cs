﻿using NUnit.Framework;
using Utau.Elements;

namespace utau_overflags.Attributes.Flags.EditTypes
{
    internal class CalculatorTest : EditTypeTest
    {
        [Test]
        public void Flagsの計算()
        {
            UtauElement elm = EditedElement("Y10B50", CreateEditType("B%50"));
            Assert.That(elm["Flags"], Is.EqualTo("Y10B25"));
        }

        [Test]
        public void CalculatorのToStringのテスト()
        {
            Assert.That(CreateEditType("B5").ToString(), Is.EqualTo("「B5」で計算"));
        }

        private EditType CreateEditType(string flag)
        {
            return new FlagsCalculator(flag);
        }
    }
}