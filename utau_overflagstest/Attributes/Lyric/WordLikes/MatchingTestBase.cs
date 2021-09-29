using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.Attributes.Lyric.WordLikes
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
