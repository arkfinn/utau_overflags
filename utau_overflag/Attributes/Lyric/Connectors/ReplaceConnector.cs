using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.Attributes.Lyric.Connectors
{
    public class ReplaceConnector : Connector
    {
        internal const string MethodText = "セット";
    
        protected ReplaceConnector() : base() { }
        public ReplaceConnector(string word)
            : base(word)
        {
        }

        public override string Connect(string target)
        {
            return Word;
        }

        public override string Method
        {
            get { return MethodText; }
        }
    }
}
