using System;
using System.Collections.Generic;
using System.Text;

namespace Utau.OverFlags.Domain.Commands.WordLikes
{
    public class BackwardMatching : Matching
    {
        internal const string MethodText = "後方一致";
        protected BackwardMatching() : base() { }
        public BackwardMatching(string value) : base(value) { }

        public override bool IsMatchOne(string input, string like)
        {
            return input.EndsWith(like);
        }

        public override string Method
        {
            get { return MethodText; }
        }

    }
}
