using System;
using System.Collections.Generic;
using System.Text;
using utau_overflags.Attributes.Lyric.WordLikes;
using NUnit.Framework;
namespace utau_overflags.Attributes.Lyric.WordLikes
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
