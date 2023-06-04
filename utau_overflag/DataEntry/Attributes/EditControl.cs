using System;
using Utau.OverFlags.Domain.Attributes;

namespace utau_overflags.DataEntry.Attributes
{
    public class EditControl : ChangableControl
    {
        virtual public EditBase Export() { return null; }
        virtual public void Import(EditBase cond) { }
    }
}
