using NUnit.Framework;

namespace Utau.OverFlags.Domain.Commands.WordLikes
{
    [TestFixture]
    public class PartialMatchingTest : MatchingTestBase
    {
        [TestCase("うあいう", true)]
        [TestCase("うあうい", false)]
        public void IsMatchTest(string target, bool expected)
        {
            ShouldMatch("あい", target, expected);
        }

        protected override Matching CreateMatching(string value)
        {
            return new PartialMatching(value);
        }
    }
}
