using System.Xml.Serialization;
using Utau.Elements;
using Utau.OverFlags.Domain.Commands.WordLikes;

namespace Utau.OverFlags.Domain.Attributes.Lyric
{
    public class LyricCondition : CondBase
    {
        public LyricCondition() : this(new ExactMatching(""))
        {
        }

        public LyricCondition(Matching matching)
        {
            Matching = matching;
        }

        [XmlElement(typeof(Matching))]
        [XmlElement(typeof(ExactMatching))]
        [XmlElement(typeof(PartialMatching))]
        [XmlElement(typeof(ForwardMatching))]
        [XmlElement(typeof(BackwardMatching))]
        public Matching Matching;

        public string Word
        {
            get { return Matching.Value; }
        }

        override protected bool DecideApply(UtauElement elm)
        {
            return Matching.IsMatch(elm.Lyric);
        }

        override public string ToString()
        {
            return Matching.ToString();
        }
    }
}