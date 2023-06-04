using System;
using System.Collections.Generic;
using System.Text;
using Utau.OverFlags.Domain.Commands.Connectors;

namespace Utau.OverFlags.Domain.Commands.Connectors
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
