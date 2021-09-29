using NUnit.Framework;
using Utau.OverFlags.Domain.CalculateCommands;

namespace Utau.Domain.Flags.Calculators
{
    internal class CalculatorTest
    {
        [TestCase(1, 10)]
        [TestCase(1, 20)]
        public void _常にsetを返す(int value, int set)
        {
            CalculateCommand op = new AssignmentCommand(set);
            Assert.That(op.Calculate(value), Is.EqualTo(set));
        }

        [TestCase(1, 2, 3)]
        [TestCase(2, 3, 5)]
        public void _valueとaddを足した値を返す(int value, int add, int excepted)
        {
            CalculateCommand op = new AdditionCommand(add);
            Assert.That(op.Calculate(value), Is.EqualTo(excepted));
        }

        [TestCase(10, 2, 8)]
        [TestCase(20, 3, 17)]
        public void _valueからsubを引いた値を返す(int value, int sub, int excepted)
        {
            CalculateCommand op = new SubtractionCommand(sub);
            Assert.That(op.Calculate(value), Is.EqualTo(excepted));
        }

        [TestCase(100, 20, 20)]
        [TestCase(200, 50, 100)]
        public void _valueのpercentパーセントの値を返す(int value, int percent, int excepted)
        {
            CalculateCommand op = new PercentCommand(percent);
            Assert.That(op.Calculate(value), Is.EqualTo(excepted));
        }
    }
}