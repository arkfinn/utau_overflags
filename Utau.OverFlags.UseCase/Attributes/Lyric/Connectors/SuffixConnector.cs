using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.Attributes.Lyric.Connectors
{
    public class SuffixConnector : Connector
    {
        internal const string MethodText = "後に追加";

        protected SuffixConnector() : base() { }
        public SuffixConnector(string word)
            : base(word)
        {
        }

        public override string Connect(string target)
        {
            return target + Word;
        }

        public override string Method
        {
            get { return MethodText; }
        }
    }
}
