using System.Xml.Serialization;
using Utau.Elements;
using Utau.OverFlags.Domain.Commands.Calculations;

namespace Utau.OverFlags.Domain.Attributes.Intensity
{
    public class IntensityEdit : EditBase
    {
        public IntensityEdit() : this(new AdditionCommand(0))
        {
        }

        public IntensityEdit(CalculateCommand calc)
        {
            Calculator = calc;
        }

        [XmlElement("Calculator", typeof(CalculateCommand))]
        [XmlElement("Addition", typeof(AdditionCommand))]
        [XmlElement("Assignment", typeof(AssignmentCommand))]
        [XmlElement("Percent", typeof(PercentCommand))]
        [XmlElement("Subtraction", typeof(SubtractionCommand))]
        public CalculateCommand Calculator;

        override protected bool RunEdit(UtauElement elm)
        {
            elm.Intensity = Calculator.Calculate(elm.Intensity);
            return true;
        }

        override public string ToString()
        {
            return "音量を" + Calculator.ToString();
        }

    }
}