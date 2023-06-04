using System;
using System.Collections.Generic;
using System.Text;

namespace Utau.OverFlags.Domain.Commands.Comparers
{
    public class EqualsComparer : Comparer
    {
        protected EqualsComparer() { }
        public EqualsComparer(int value)
            : base(value)
        {
        }

        public override bool Evaluate(int target)
        {
            return Value == target;
        }

        internal const string MethodText = "と同値";
        public override string Method
        {
            get { return MethodText; }
        }

    }
}
