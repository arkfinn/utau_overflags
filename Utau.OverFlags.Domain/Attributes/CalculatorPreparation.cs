using Utau.OverFlags.Domain.Choices;
using Utau.OverFlags.Domain.Commands.Calculations;

namespace utau_overflags.Attributes
{
    public class CalculatorPreparation
    {
        public CalculateCommandChoice CreateParser()
        {
            return new CalculateCommandChoice();
        }

        public CalculateCommand CreateCalculator(string text, int value)
        {
            CalculateCommandChoice parser = CreateParser();
            return parser.Parse(text, value);
        }
    }
}