using System;
using Utau.OverFlags.Domain.Attributes;
using utau_overflags.Attributes;
namespace utau_overflags.Conditions
{
    public abstract class ConditionControl:ChangableControl
    {
        abstract public CondBase Export();
        abstract public void Import(CondBase cond);
    }
}
