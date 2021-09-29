using System.Text;

namespace Utau.Domain.Flags.FlagTypes
{
    public interface IFlag
    {
        string Key { get; }
        int Value { get; }

        void AppendAttribute(StringBuilder target);

        string ToAttribute();
    }
}