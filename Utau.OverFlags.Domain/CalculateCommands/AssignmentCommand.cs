namespace Utau.OverFlags.Domain.CalculateCommands
{
    public class AssignmentCommand : CalculateCommand
    {
        protected AssignmentCommand()
        {
        }

        public AssignmentCommand(int value)
            : base(value)
        {
        }

        public override int Calculate(int i)
        {
            return Value;
        }

        internal const string MethodText = "に設定";

        public override string Method
        {
            get { return MethodText; }
        }

        internal const string ShortMethodText = "";

        public override string ShortMethod
        {
            get { return ShortMethodText; }
        }
    }
}