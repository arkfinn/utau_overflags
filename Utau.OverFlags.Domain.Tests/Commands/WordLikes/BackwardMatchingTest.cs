using NUnit.Framework;

namespace Utau.OverFlags.Domain.Commands.WordLikes
{
    [TestFixture]
    public class BackwardMatchingTest : MatchingTestBase
    {
        [TestCase("うあい", true)]
        [TestCase("あいう", false)]
        public void IsMatchTest(string target, bool expected)
        {
            ShouldMatch("あい", target, expected);
        }

        protected override Matching CreateMatching(string value)
        {
            return new BackwardMatching(value);
        }
    }
}
