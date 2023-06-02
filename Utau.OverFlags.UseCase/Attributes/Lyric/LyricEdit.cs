using System.Xml.Serialization;
using Utau.Elements;
using utau_overflags.Attributes.Lyric.Connectors;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Lyric
{
    public class LyricEdit : EditBase
    {
        public LyricEdit() : this(new ReplaceConnector(""))
        {
        }

        public LyricEdit(Connector wordConnector)
        {
            WordConnector = wordConnector;
        }

        [XmlElement(typeof(Connector))]
        [XmlElement(typeof(ReplaceConnector))]
        [XmlElement(typeof(PrefixConnector))]
        [XmlElement(typeof(SuffixConnector))]
        public Connector WordConnector;

        override protected bool RunEdit(UtauElement elm)
        {
            elm.Lyric = WordConnector.Connect(elm.Lyric);
            return true;
        }

        override public string ToString()
        {
            return "歌詞に" + WordConnector.ToString();
        }

    }
}