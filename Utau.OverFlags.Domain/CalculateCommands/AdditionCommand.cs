namespace Utau.OverFlags.Domain.CalculateCommands
{
    public class AdditionCommand : CalculateCommand
    {
        protected AdditionCommand()
        {
        }

        public AdditionCommand(int value)
            : base(value)
        {
        }

        public override int Calculate(int i)
        {
            return i + Value;
        }

        internal const string MethodText = "加算";

        public override string Method
        {
            get { return MethodText; }
        }

        internal const string ShortMethodText = "+";

        public override string ShortMethod
        {
            get { return ShortMethodText; }
        }
    }
}