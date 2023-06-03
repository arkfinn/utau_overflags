using NUnit.Framework;
using Utau.Elements;

namespace Utau.OverFlags.Domain.Commands.Flags
{
    internal class FlagsAdditionCommandTest : FlagsCommandTest
    {
        [Test]
        public void Flagsの後ろに追加()
        {
            UtauElement elm = EditedElement("Y10", new FlagsAddition("B5"));
            Assert.That(elm["Flags"], Is.EqualTo("Y10B5"));
        }

        [Test]
        public void AdditionのToStringのテスト()
        {
            Assert.That(new FlagsAddition("B5").ToString(), Is.EqualTo("「B5」を追加"));
        }
    }
}