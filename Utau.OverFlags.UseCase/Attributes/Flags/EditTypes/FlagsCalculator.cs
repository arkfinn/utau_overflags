﻿using Utau.Domain.Flags;
using Utau.OverFlags.Domain.Flags;

namespace utau_overflags.Attributes.Flags.EditTypes
{
    public class FlagsCalculator : EditType
    {
        protected FlagsCalculator() : base()
        {
        }

        public FlagsCalculator(string p) : base(p)
        {
        }

        public override FlagCalculatePlan CreatePlan()
        {
            return new FlagCalculatePlanParser().Parse(Plan);
        }

        public override FlagList Edit(FlagList baseList)
        {
            return CreatePlan().Calculate(baseList);
        }

        internal const string MethodText = "で計算";

        public override string Method
        {
            get { return MethodText; }
        }
    }
}