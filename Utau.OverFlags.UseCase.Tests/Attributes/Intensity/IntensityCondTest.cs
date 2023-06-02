using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Utau.Elements;
using utau_overflags.Attributes.Comparers;
using UtauPluginSet;

namespace utau_overflags.Attributes.Intensity
{
    class IntensityCondTest
    {

        [Test]
        public void Intensityが50と同値のとき一致()
        {
            IntensityCondition cond = ConditionOf(new EqualsComparer(50));
            ApplyTrueAndToStringEquals(cond, 50, "音量が50と同値");
            ApplyFalse(cond, 49);
            ApplyFalse(cond, 51);
        }

        [Test]
        public void Intensityが50以上のとき一致()
        {
            IntensityCondition cond = ConditionOf(new MoreThanEqualsComparer(50));
            ApplyTrueAndToStringEquals(cond, 50, "音量が50以上");
            ApplyFalse(cond, 49);
        }

        [Test]
        public void Intensityが50以下のとき一致()
        {
            IntensityCondition cond = ConditionOf(new LessThanEqualsComparer(50));
            ApplyTrueAndToStringEquals(cond, 50, "音量が50以下");
            ApplyFalse(cond, 51);
        }

        private UtauElement ElementOf(int intensity)
        {
            UtauElement e = new UtauElement();
            e.Intensity = intensity;
            return e;
        }

        private IntensityCondition ConditionOf(Comparer op)
        {
            IntensityCondition c = new IntensityCondition(op);
            c.Enabled = true;
            return c;
        }

        private void ApplyTrueAndToStringEquals(IntensityCondition cond, int intensity, string output)
        {
            Assert.IsTrue(cond.IsApply(ElementOf(intensity)));
            Assert.AreEqual(output, cond.ToString());
        }

        private void ApplyFalse(IntensityCondition cond, int intensity)
        {
            Assert.IsFalse(cond.IsApply(ElementOf(intensity)));
        }
    }
}
