using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using utau_overflags.Attributes.Comparers;

namespace utau_overflagstest.Attributes.Comparers
{
    class LessThanEqualsComparerTest
    {
        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(2, false)]
        public void compareにて1以下のときtrueとなる(int compare, bool expected)
        {
            Assert.That(CreateComparer(1).Evaluate(compare), Is.EqualTo(expected));
        }

        [Test]
        public void ToStringで1以下が出力される()
        {
            Assert.That(CreateComparer(1).ToString(), Is.EqualTo("1以下"));
        }

        private Comparer CreateComparer(int value)
        {
            return new LessThanEqualsComparer(value);
        }

    }
}
