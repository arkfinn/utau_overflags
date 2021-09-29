using System;
using utau_overflags.Attributes;
namespace utau_overflags.Conditions
{
    public abstract class ConditionControl:ChangableControl
    {
        abstract public CondBase Export();
        abstract public void Import(utau_overflags.Conditions.CondBase cond);
    }
}
