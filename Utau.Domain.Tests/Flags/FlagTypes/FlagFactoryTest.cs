using NUnit.Framework;
using System;

namespace Utau.Domain.Flags.FlagTypes.Tests
{
    [TestFixture]
    internal class FlagFactoryTest
    {
        [Test]
        public void フラグを値付きで作成する()
        {
            var flag = new FlagFactory().CreateFlag("g", -20);
            Assert.AreEqual("g-20", flag.ToAttribute());
        }

        [Test]
        public void Valueをもたないフラグを値付きで作成する()
        {
            var flag = new FlagFactory().CreateFlag("N", 0);
            Assert.AreEqual("N", flag.ToAttribute());
        }

        [Test]
        public void Key名がnullの場合の例外()
        {
            var factory = new FlagFactory();
            var ex = Assert.Throws<ArgumentNullException>(() => factory.CreateFlag(null, "0"));
        }

        [Test]
        public void Valueが数字で無い場合の例外()
        {
            var factory = new FlagFactory();
            var ex = Assert.Throws<ArgumentException>(() => factory.CreateFlag("test", "test"));
        }

        [Test]
        public void Keyが利用可能なフラグで無い場合の例外()
        {
            var factory = new FlagFactory();
            var ex = Assert.Throws<ArgumentException>(() => factory.CreateNoValueFlag("test"));
        }
    }
}