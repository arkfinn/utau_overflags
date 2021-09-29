using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.FlagCouplers
{
    abstract class FlagCoupler
    {
        protected readonly string Value;
        public FlagCoupler(string value)
        {
            this.Value = value;
        }
        public abstract string Connect(string flags);
    }
}
