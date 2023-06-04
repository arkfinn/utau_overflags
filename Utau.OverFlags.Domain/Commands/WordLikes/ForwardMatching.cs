using System;
using System.Collections.Generic;
using System.Text;

namespace Utau.OverFlags.Domain.Commands.WordLikes
{
    public class ForwardMatching : Matching
    {
        internal const string MethodText = "前方一致";
        protected ForwardMatching() : base() { }
        public ForwardMatching(string value) : base(value) { }
        public override bool IsMatchOne(string input, string like)
        {
            return input.StartsWith(like);
        }

        public override string Method
        {
            get { return MethodText; }
        }
    }
}
