using NUnit.Framework;

namespace Utau.Domain.PitchBends
{
    [TestFixture()]
    public class PitchBendListTests
    {
        [Test()]
        public void PitchBendListTest()
        {
            var list = new PitchBendList("1;2", "3,4,5,6", "7,8,9,10");
            Assert.AreEqual("1;2", list.GetPBS());

            // 未実装
            // Assert.AreEqual("3,4,5,6", list.GetPBW());
            // Assert.AreEqual("7,8,9,10", list.GetPBY());
        }
    }
}