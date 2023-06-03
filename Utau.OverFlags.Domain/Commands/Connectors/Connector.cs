using System;

namespace Utau.OverFlags.Domain.Commands.Connectors
{
    abstract public class Connector
    {
        protected Connector() { }
        public string Word;
        public Connector(string word)
        {
            Word = word;
        }

        abstract public string Method { get; }
        abstract public string Connect(string target);

        public override string ToString()
        {
            return "「" + Word + "」を" + Method;
        }
    }
}
