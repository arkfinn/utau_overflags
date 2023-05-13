using Utau.Elements;

namespace utau_overflags.Attributes.Flags.EditTypes
{
    internal class EditTypeTest
    {
        protected UtauElement EditedElement(string flags, EditType editType)
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