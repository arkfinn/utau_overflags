using NUnit.Framework;

namespace Utau.OverFlags.Domain.Commands.WordLikes
{
    [TestFixture]
    public class ForwardMatchingTest : MatchingTestBase
    {
        [TestCase("あいう", true)]
        [TestCase("うあい", false)]
        public void IsMatchTest(string target, bool expected)
        {
            ShouldMatch("あい", target, expected);
        }

        protected override Matching CreateMatching(string value)
        {
            return new ForwardMatching(value);
        }
    }
}
