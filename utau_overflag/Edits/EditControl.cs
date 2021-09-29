using System;
using utau_overflags.Attributes;
namespace utau_overflags.Edits
{
    public  class EditControl:ChangableControl
    {
        virtual public EditBase Export() { return null; }
        virtual public void Import(EditBase cond){}
    }
}
