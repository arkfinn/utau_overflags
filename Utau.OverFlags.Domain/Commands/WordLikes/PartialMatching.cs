using System;
using System.Collections.Generic;
using System.Text;

namespace Utau.OverFlags.Domain.Commands.WordLikes
{
    [Serializable]
    public class PartialMatching : Matching
    {
        internal const string MethodText = "部分一致";
        protected PartialMatching() : base() { }
        public PartialMatching(string value) : base(value) { }
        public override bool IsMatchOne(string input, string like)
        {
            return input.Contains(like);
        }

        public override string Method
        {
            get { return MethodText; }
        }
    }
}
