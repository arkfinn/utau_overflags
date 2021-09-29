using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.Attributes.Lyric.Connectors
{
    class ConnectorParser: ChoiceSet
    {
        public Connector Parse(string method, string word)
        {
            switch (method)
            {
                case "Set":
                case ReplaceConnector.MethodText:
                    return new ReplaceConnector(word);
                case "Prefix":
                case PrefixConnector.MethodText:
                    return new PrefixConnector(word);
                case "Suffix":
                case SuffixConnector.MethodText:
                    return new SuffixConnector(word);
            }
            throw new ArgumentException("invalid method:" + method);
        }

        private readonly string[] ParsableWords = { 
            ReplaceConnector.MethodText, 
            PrefixConnector.MethodText, 
            SuffixConnector.MethodText };

        public string[] Choices
        {
            get { return ParsableWords; }
        }
    }
}
