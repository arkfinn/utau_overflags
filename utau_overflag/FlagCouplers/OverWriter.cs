using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.FlagCouplers
{
    class OverWriter:FlagCoupler
    {
        public OverWriter(string value) : base(value) { }

        public override string Connect(string flags)
        {
            return Value;
        }
    }
}
