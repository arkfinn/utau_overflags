using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace utau_overflags.Attributes.Lyric.WordLikes
{
    [Serializable]
    public class ExactMatching : Matching
    {
        internal const string MethodText = "完全一致";
        protected ExactMatching() : base() { }
        public ExactMatching(string value) : base(value) { }
        public override bool IsMatchOne(string input, string like)
        {
            return (input == like);
        }

        public override string Method
        {
            get { return MethodText; }
        }

    }
}
