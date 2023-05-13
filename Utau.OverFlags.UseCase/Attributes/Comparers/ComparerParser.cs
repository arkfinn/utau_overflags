using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.Attributes.Comparers
{
    public class ComparerParser : ChoiceSet
    {

        public Comparer Parse(string method, int value)
        {
            switch (method)
            {
                case "More":
                case MoreThanEqualsComparer.MethodText:
                    return new MoreThanEqualsComparer(value);
                case "Equal":
                case EqualsComparer.MethodText:
                    return new EqualsComparer(value);
                case "Less":
                case LessThanEqualsComparer.MethodText:
                    return new LessThanEqualsComparer(value);
            }
            throw new ArgumentException("invalid method:" + method);
        }

        private readonly string[] ParsableWords = { 
            MoreThanEqualsComparer.MethodText, 
            EqualsComparer.MethodText,
            LessThanEqualsComparer.MethodText};

        public string[] Choices
        {
            get { return ParsableWords; }
        }
    }
}
