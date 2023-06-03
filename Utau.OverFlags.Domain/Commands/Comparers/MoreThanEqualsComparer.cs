using System;
using System.Collections.Generic;
using System.Text;
using Utau.OverFlags.Domain.Commands.Comparers;

namespace Utau.OverFlags.Domain.Commands.Comparers
{
    public class MoreThanEqualsComparer : Comparer
    {
        protected MoreThanEqualsComparer() { }
        public MoreThanEqualsComparer(int value)
            : base(value)
        {
        }

        public override bool Evaluate(int target)
        {
            return Value <= target;
        }

        internal const string MethodText = "以上";
        public override string Method
        {
            get { return MethodText; }
        }
    }
}
