using System;
using System.Collections.Generic;
using System.Text;
using Utau.OverFlags.Domain.Commands.Comparers;

namespace Utau.OverFlags.Domain.Commands.Comparers
{
    public class LessThanEqualsComparer : Comparer
    {
        protected LessThanEqualsComparer() { }
        public LessThanEqualsComparer(int value)
            : base(value)
        {
        }

        public override bool Evaluate(int target)
        {
            return Value >= target;
        }

        internal const string MethodText = "以下";
        public override string Method
        {
            get { return MethodText; }
        }
    }
}
