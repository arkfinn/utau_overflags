using NUnit.Framework;
using Utau.Domain.Flags;

namespace Utau.OverFlags.Domain.Flags.Tests
{
    [TestFixture]
    public class FlagCalculatePlanTest
    {
        [Test]
        public void ParseMathTest()
        {
            var parser = new FlagCalculatePlanParser();
            FlagCalculatePlan d = parser.Parse("g-20Y0y%5");
            Assert.AreEqual(10, d["g"].Calculate(30));
            Assert.AreEqual(0, d["Y"].Calculate(10));
            Assert.AreEqual(10, d["y"].Calculate(200));
        }

        [Test]
        public void CalculateTest()
        {
            var flags = new FlagParser().Parse("g30Y50y80");
            var plan = new FlagCalculatePlanParser().Parse("g-20Y0y%25");

            FlagList res = plan.Calculate(flags);

            Assert.AreEqual(10, res["g"].Value);
            Assert.AreEqual(0, res["Y"].Value);
            Assert.AreEqual(20, res["y"].Value);
        }
    }
}