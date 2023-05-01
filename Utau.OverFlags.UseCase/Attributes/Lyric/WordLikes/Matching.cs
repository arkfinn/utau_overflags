using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml.Serialization;

namespace utau_overflags.Attributes.Lyric.WordLikes
{
    [Serializable]
    public abstract class Matching
    {
        protected Matching() { }
        public Matching(string value)
        {
            this.Value = value;
        }
        public string Value;

        public bool IsMatch(string input)
        {
            foreach (string w in Value.Split(','))
            {
                if (IsMatchOne(input, w)) return true;
            }
            return false;
        }

        abstract public string Method { get; }
        abstract public bool IsMatchOne(string input, string like);

        override public string ToString()
        {
            return "「" + Value + "」と" + Method;
        }
    }
}
