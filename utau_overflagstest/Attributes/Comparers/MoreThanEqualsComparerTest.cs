using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using utau_overflags.Attributes.Comparers;

namespace utau_overflagstest.Attributes.Comparers
{
    class MoreThanEqualsComparerTest
    {
        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        public void compareにて1以上のときtrueとなる(int compare, bool expected)
        {
            Assert.That(CreateComparer(1).Evaluate(compare), Is.EqualTo(expected));
        }

        [Test]
        public void ToStringで1以上が出力される()
        {
            Assert.That(CreateComparer(1).ToString(), Is.EqualTo("1以上"));
        }

        private Comparer CreateComparer(int value)
        {
            return new MoreThanEqualsComparer(value);
        }

    }
}
