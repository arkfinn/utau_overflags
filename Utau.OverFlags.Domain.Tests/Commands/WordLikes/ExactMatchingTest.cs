﻿using NUnit.Framework;

namespace Utau.OverFlags.Domain.Commands.WordLikes
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
