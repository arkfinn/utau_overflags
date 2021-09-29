using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.WordCouplers
{
    interface WordCoupler
    {
        string Execute(string text);
    }
}
