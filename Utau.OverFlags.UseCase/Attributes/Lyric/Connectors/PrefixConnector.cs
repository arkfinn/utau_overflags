using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.Attributes.Lyric.Connectors
{
    public class PrefixConnector : Connector
    {
        internal const string MethodText = "前に追加";

        protected PrefixConnector() : base() { }
        public PrefixConnector(string word)
            : base(word)
        {
        }

        public override string Connect(string target)
        {
            return Word + target;
        }

        public override string Method
        {
            get { return MethodText; }
        }
    }
}
