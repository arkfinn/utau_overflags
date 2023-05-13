using Utau.Domain.Flags;
using Utau.OverFlags.Domain.Flags;

namespace utau_overflags.Attributes.Flags.EditTypes
{
    public class FlagsAddition : utau_overflags.Attributes.Flags.EditTypes.EditType
    {
        protected FlagsAddition() : base()
        {
        }

        public FlagsAddition(string plan) : base(plan)
        {
        }

        public override FlagCalculatePlan CreatePlan()
        {
            return new FlagCalculatePlanParser().Parse(Plan);
        }

        public override FlagList Edit(FlagList baseList)
        {
            return new FlagParser().Parse(Plan).Merge(baseList);
        }

        internal const string MethodText = "を追加";

        public override string Method
        {
            get { return MethodText; }
        }
    }
}