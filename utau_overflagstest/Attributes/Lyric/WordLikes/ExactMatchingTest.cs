using System;
using System.Collections.Generic;
using System.Text;
using utau_overflags.Attributes.Lyric.WordLikes;
using NUnit.Framework;
namespace utau_overflags.Attributes.Lyric.WordLikes
{
    [TestFixture]
    public class ExactMatchingTest : MatchingTestBase
    {
        [TestCase("あい", true)]
        [TestCase("うあい", false)]
        public void IsMatchTest(string target, bool expected)
        {
            ShouldMatch("あい", target, expected);
        }

        [TestCase("あい", true)]
        [TestCase("うえ", true)]
        [TestCase("うあい", false)]
        public void IsAnyMatchTest(string target, bool expected)
        {
            ShouldMatch("あい,うえ", target, expected);
        }

        protected override Matching CreateMatching(string value)
        {
            return new ExactMatching(value);
        }
    }
}
