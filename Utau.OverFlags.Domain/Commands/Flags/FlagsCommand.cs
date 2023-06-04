using Utau.Domain.Flags;
using Utau.OverFlags.Domain.Flags;

namespace Utau.OverFlags.Domain.Commands.Flags
{
    public abstract class FlagsCommand
    {
        protected FlagsCommand()
        {
        }

        public FlagsCommand(string plan)
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