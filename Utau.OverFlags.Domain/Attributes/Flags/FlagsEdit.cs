using System.Xml.Serialization;
using Utau.Elements;
using Utau.OverFlags.Domain.Commands.Flags;

namespace Utau.OverFlags.Domain.Attributes.Flags
{
    public class FlagsEdit : EditBase
    {
        public FlagsEdit() : this(new FlagsAddition(""))
        {
        }

        public FlagsEdit(FlagsCommand editType)
        {
            EditType = editType;
        }

        [XmlElement(typeof(FlagsCommand))]
        [XmlElement(typeof(FlagsAddition))]
        [XmlElement(typeof(FlagsCalculator))]
        [XmlElement(typeof(FlagsOverWriter))]
        [XmlElement(typeof(FlagsReplacer))]
        public FlagsCommand EditType;

        protected override bool RunEdit(UtauElement elm)
        {
            elm.SetFlagsList(EditType.Edit(elm.GetFlagsList()));
            return true;
        }

        override public string ToString()
        {
            return "Flags" + EditType.ToString();
        }

    }
}