using NUnit.Framework;

namespace Utau.OverFlags.Domain.Commands.WordLikes
{
    abstract public class MatchingTestBase
    {
        protected void ShouldMatch(string cond, string target, bool expected)
        {
            Assert.That(CreateMatching(cond).IsMatch(target), Is.EqualTo(expected));
        }

        abstract protected Matching CreateMatching(string value);
    }
}
