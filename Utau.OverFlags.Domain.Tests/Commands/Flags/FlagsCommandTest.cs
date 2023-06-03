using Utau.Elements;

namespace Utau.OverFlags.Domain.Commands.Flags
{
    internal class FlagsCommandTest
    {
        protected UtauElement EditedElement(string flags, FlagsCommand editType)
        {
            UtauElement elm = CreateElement(flags);
            elm.SetFlagsList(editType.Edit(elm.GetFlagsList()));
            return elm;
        }

        protected UtauElement CreateElement(string flags)
        {
            UtauElement elm = new UtauElement();
            elm["Flags"] = flags;
            return elm;
        }
    }
}