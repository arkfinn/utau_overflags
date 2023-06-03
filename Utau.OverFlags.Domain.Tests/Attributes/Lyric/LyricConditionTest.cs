using NUnit.Framework;
using Utau.Elements;
using Utau.OverFlags.Domain.Commands.WordLikes;

namespace Utau.OverFlags.Domain.Attributes.Lyric
{
    class LyricConditionTest
    {
        [Test]
        public void _い_と完全一致()
        {
            ApplyTrueAndToStringEquals(new ExactMatching( "い"),"い", "「い」と完全一致");
        }

        [Test]
        public void _い_と部分一致()
        {
            ApplyTrueAndToStringEquals(new PartialMatching("い"), "あいあ", "「い」と部分一致");
        }

        [Test]
        public void _い_と前方一致()
        {
            ApplyTrueAndToStringEquals(new ForwardMatching("い"),"いあ", "「い」と前方一致");
        }

        [Test]
        public void _い_と後方一致()
        {
            ApplyTrueAndToStringEquals(new BackwardMatching("い"),"あい","「い」と後方一致");
        }

        private UtauElement ElementOf(string word)
        {
            UtauElement e = new UtauElement();
            e.Lyric = word;
            return e;
        }

        private void ApplyTrueAndToStringEquals(Matching matching, string word, string output)
        {
            LyricCondition c = ConditionOf(matching);
            Assert.IsTrue(c.IsApply(ElementOf(word)));
            Assert.AreEqual(output, c.ToString());
        }

        private LyricCondition ConditionOf(Matching matching)
        {
            LyricCondition c = new LyricCondition(matching);
            c.Enabled = true;
            return c;
        }

    }
}
