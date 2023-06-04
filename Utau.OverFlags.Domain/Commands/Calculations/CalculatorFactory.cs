using System;

namespace Utau.OverFlags.Domain.Commands.Calculations
{
    internal class CalculatorFactory
    {
        public CalculateCommand Create(string op, string valueText)
        {
            if (!int.TryParse(valueText, out int value))
            {
                throw new ArgumentException(valueText + " is invalid value.");
            }
            switch (op)
            {
                case "+":
                    return new AdditionCommand(value);

                case "-":
                    return new SubtractionCommand(value);

                case "%":
                    return new PercentCommand(value);

                default:
                    return new AssignmentCommand(value);
            }
        }
    }
}