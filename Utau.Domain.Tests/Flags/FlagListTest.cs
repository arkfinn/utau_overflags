using NUnit.Framework;

namespace Utau.Domain.Flags.Tests
{
    [TestFixture]
    public class FlagListTest
    {
        /*
         * to see : http://kenchan22.web.fc2.com/i/utauproperty/utauproperty.html#7-3
         */

        [Test]
        public void プラス演算子を許容する()
        {
            // g, tのみ
            var parser = new FlagParser();
            FlagList d = parser.Parse("g+20t+10");
            Assert.AreEqual(20, d["g"].Value);
            Assert.AreEqual(10, d["t"].Value);
        }

        [Test]
        public void Nフラグは値なしでも認識される()
        {
            var parser = new FlagParser();
            FlagList d = parser.Parse("g-20NY0");
            Assert.AreEqual(-20, d["g"].Value);
            Assert.AreEqual(0, d["Y"].Value);
            Assert.AreEqual(0, d["N"].Value);
        }

        // TODO: 制限値を超えた場合の処理

        // 大文字小文字は区別される。
        [TestCase("g-20Y0y5", "g-20Y0y5")]
        // +は受け付けるが出力時は省略される。
        [TestCase("Test-20g+20Y0Bre5", "Test-20g20Y0Bre5")]
        // 末尾のフラグは値が無ければ無視される。
        [TestCase("Test-20Y0Bre5Y", "Test-20Y0Bre5")]
        // Nフラグは値無しで受け付ける。
        [TestCase("g-20NY0", "g-20NY0")]
        // Nフラグは末尾にあっても受け付ける。
        [TestCase("g-20Y0N", "g-20Y0N")]
        public void ToAttributeTest(string given, string then)
        {
            var parser = new FlagParser();
            FlagList d = parser.Parse(given);
            Assert.AreEqual(then, d.ToAttribute());
        }

        [Test]
        public void ToDictionaryTest()
        {
            var parser = new FlagParser();
            var d = parser.Parse("g+20t+10").ToDictionary();
            Assert.AreEqual(20, d["g"].Value);
            Assert.AreEqual(10, d["t"].Value);
        }

        [Test]
        public void MergeTest()
        {
            var parser = new FlagParser();
            var src = parser.Parse("g+20t+10");
            var d = src.Merge(parser.Parse("g+30y10"));
            // 同一フラグの場合、上書きはされない。
            Assert.AreEqual(20, d["g"].Value);
            Assert.AreEqual(10, d["t"].Value);
            Assert.AreEqual(10, d["y"].Value);
        }
    }
}