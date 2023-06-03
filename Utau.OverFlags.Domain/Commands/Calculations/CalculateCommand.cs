namespace Utau.OverFlags.Domain.Commands.Calculations
{
    public abstract class CalculateCommand
    {
        protected CalculateCommand()
        {
        }

        public CalculateCommand(int value)
        {
            Value = value;
        }

        public int Value;

        abstract public int Calculate(int i);

        public override string ToString()
        {
            return Value + Method;
        }

        internal string ToShortString(bool forMath)
        {
            return ShortMethod + Value;
        }

        public abstract string Method { get; }
        public abstract string ShortMethod { get; }
    }
}