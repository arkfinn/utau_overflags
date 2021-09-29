using Utau.Domain.Flags;

namespace utau_overflags.FlagCouplers
{
    internal class Replacer : FlagCoupler
    {
        public Replacer(string value) : base(value)
        {
        }

        public override string Connect(string flags)
        {
            var parser = new FlagParser();
            return parser.Parse(Value).Merge(parser.Parse(flags)).ToAttribute();
        }
    }
}