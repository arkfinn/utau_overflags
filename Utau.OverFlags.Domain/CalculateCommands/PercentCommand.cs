using System;

namespace Utau.OverFlags.Domain.CalculateCommands
{
    public class PercentCommand : CalculateCommand

    {
        protected PercentCommand()
        {
        }

        public PercentCommand(int value)
            : base(value)
        {
        }

        public override int Calculate(int i)
        {
            return Convert.ToInt32(Math.Round((double)i * ((double)Value / 100)));
        }

        internal const string MethodText = "%に変更";

        public override string Method
        {
            get { return MethodText; }
        }

        internal const string ShortMethodText = "%";

        public override string ShortMethod
        {
            get { return ShortMethodText; }
        }
    }
}