using System;
using System.Collections.Generic;
using System.Text;
using Utau.OverFlags.Domain.Commands.Connectors;

namespace Utau.OverFlags.Domain.Choices
{
    public class ConnectorChoice : IChoicable
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
