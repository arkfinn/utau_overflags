namespace Utau.Domain.Flags
{
    public class FlagRule
    {
        public bool IsValueLetter(string letter)
        {
            return (char.IsDigit(letter, 0) || letter == "-" || letter == "+");
        }

        public bool IsNoValueKey(string key)
        {
            return key == "N";
        }
    }
}