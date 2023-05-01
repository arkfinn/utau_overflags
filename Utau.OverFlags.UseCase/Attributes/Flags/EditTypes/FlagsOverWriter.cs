using Utau.Domain.Flags;
using Utau.OverFlags.Domain.Flags;

namespace utau_overflags.Attributes.Flags.EditTypes
{
    public class FlagsOverWriter : EditType
    {
        protected FlagsOverWriter() : base()
        {
        }

        public FlagsOverWriter(string p) : base(p)
        {
        }

        public override FlagCalculatePlan CreatePlan()
        {
            return new FlagCalculatePlanParser().Parse(Plan);
        }

        public override FlagList Edit(FlagList baseList)
        {
            return new FlagParser().Parse(Plan);
        }

        internal const string MethodText = "で上書き";

        public override string Method
        {
            get { return MethodText; }
        }
    }
}