using Utau.OverFlags.Domain.CalculateCommands;
using UtauPluginSet.Attributes.Calculators;

namespace utau_overflags.Attributes
{
    internal class CalculatorPreparation
    {
        public CalculatorParser CreateParser()
        {
            return new CalculatorParser();
        }

        public CalculateCommand CreateCalculator(string text, int value)
        {
            CalculatorParser parser = CreateParser();
            return parser.Parse(text, value);
        }
    }
}