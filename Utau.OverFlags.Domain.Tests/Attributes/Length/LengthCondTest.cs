using NUnit.Framework;
using Utau.Elements;
using Utau.OverFlags.Domain.Commands.Comparers;

namespace Utau.OverFlags.Domain.Attributes.Length
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
