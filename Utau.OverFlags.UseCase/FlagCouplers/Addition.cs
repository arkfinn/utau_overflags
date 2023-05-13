using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.FlagCouplers
{
    class Addition:FlagCoupler
    {
        public Addition(string value) : base(value) { }

        public override string Connect(string flags)
        {
            return flags + Value;
        }
    }
}
