using System.Xml.Serialization;
using Utau.Elements;
using Utau.OverFlags.Domain.CalculateCommands;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Moduration
{
    public class ModurationEdit : EditBase
    {
        public ModurationEdit() : this(new AdditionCommand(0))
        {
        }

        public ModurationEdit(CalculateCommand calc)
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
            elm.Moduration = Calculator.Calculate(elm.Moduration);
            return true;
        }

        override public string ToString()
        {
            return "モジュレーションを" + Calculator.ToString();
        }

    }
}