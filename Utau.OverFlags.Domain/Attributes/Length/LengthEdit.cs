using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Utau.Elements;
using Utau.OverFlags.Domain.Commands.Calculations;

namespace Utau.OverFlags.Domain.Attributes.Length
{
    public class LengthEdit : EditBase
    {
        public LengthEdit() : this(new AdditionCommand(0))
        {
        }

        public LengthEdit(CalculateCommand calc)
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
            elm.Intensity = Calculator.Calculate(elm.Length);
            return true;
        }

        override public string ToString()
        {
            return "音長を" + Calculator.ToString();
        }

    }
}
