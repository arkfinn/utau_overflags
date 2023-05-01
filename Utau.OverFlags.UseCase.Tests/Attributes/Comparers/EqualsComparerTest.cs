using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using utau_overflags.Attributes.Comparers;

namespace utau_overflagstest.Attributes.Comparers
{
    class EqualsComparerTest
    {
        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(2, false)]
        public void compareにて1と同値のときtrueとなる(int compare, bool expected)
        {
            EqualsComparer comparer = new EqualsComparer(1);
            Assert.That(comparer.Evaluate(compare), Is.EqualTo(expected));
        }

        [Test]
        public void ToStringで1と同値が出力される()
        {
            EqualsComparer comparer = new EqualsComparer(1);
            Assert.That(comparer.ToString(), Is.EqualTo("1と同値"));
      
        }

    }
}
