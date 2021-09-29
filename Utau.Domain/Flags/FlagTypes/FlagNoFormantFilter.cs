using System.Text;

namespace Utau.Domain.Flags.FlagTypes
{
    public class FlagNoFormantFilter : IFlag
    {
        public string Key => "N";

        public int Value => 0;

        public void AppendAttribute(StringBuilder target)
        {
            target.Append(Key);
        }

        public string ToAttribute()
        {
            return Key;
        }
    }
}