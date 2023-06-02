using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Utau.Elements;
using utau_overflags.Attributes.Comparers;
using UtauPluginSet;

namespace utau_overflags.Attributes.Length
{
    class LengthCondTest
    {
        //Lengthが50以上
        //「50」以上と出力
        [Test]
        public void Lengthが50以上のとき一致()
        {
            Comparer comparer = new MoreThanEqualsComparer(50);
            ApplyTrueAndToStringEquals(comparer, 50, "音長が50以上");
            ApplyFalse(comparer, 49);
        }

        private LengthCondition ConditionOf(Comparer op)
        {
            LengthCondition c = new LengthCondition(op);
            c.Enabled = true;
            return c;
        }

        private UtauElement ElementOf(int length)
        {
            UtauElement e = new UtauElement();
            e.Length = length;
            return e;
        }

        private void ApplyTrueAndToStringEquals(Comparer like, int length, string output)
        {
            LengthCondition c = ConditionOf(like);
            Assert.IsTrue(c.IsApply(ElementOf(length)));
            Assert.AreEqual(output, c.ToString());
        }

        private void ApplyFalse(Comparer like, int length)
        {
            LengthCondition c = ConditionOf(like);
            Assert.IsFalse(c.IsApply(ElementOf(length)));
        }
    }
}
