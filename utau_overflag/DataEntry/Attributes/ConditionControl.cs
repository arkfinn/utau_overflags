using System;
using Utau.OverFlags.Domain.Attributes;

namespace utau_overflags.DataEntry.Attributes
{
    public abstract class ConditionControl : ChangableControl
    {
        abstract public CondBase Export();
        abstract public void Import(CondBase cond);
    }
}
