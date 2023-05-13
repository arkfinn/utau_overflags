using Utau.Domain.Flags;
using Utau.OverFlags.Domain.Flags;

namespace utau_overflags.Attributes.Flags.EditTypes
{
    public abstract class EditType
    {
        protected EditType()
        {
        }

        public EditType(string plan)
        {
            Plan = plan;
        }

        public string Plan;

        public abstract FlagCalculatePlan CreatePlan();

        public abstract string Method { get; }

        public abstract FlagList Edit(FlagList baseList);

        public override string ToString()
        {
            return "「" + CreatePlan().ToString() + "」" + Method;
        }
    }
}