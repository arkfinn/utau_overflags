using Utau.Elements;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Others
{
    public class OthersEdit : EditBase
    {
        public OthersEdit(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public OthersEdit()
            : this("", "")
        {
        }

        public string Key;
        public string Value;

        override protected bool RunEdit(UtauElement elm)
        {
            elm[Key] = Value;
            return true;
        }

        override public string ToString()
        {
            return Key + "に「" + Value + "」を設定";
        }

    }
}