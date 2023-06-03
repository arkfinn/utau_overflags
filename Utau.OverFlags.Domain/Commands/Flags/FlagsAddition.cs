using Utau.Domain.Flags;
using Utau.OverFlags.Domain.Flags;

namespace Utau.OverFlags.Domain.Commands.Flags

{
    public class FlagsAddition : FlagsCommand
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