using System.Xml.Serialization;
using Utau.Elements;
using utau_overflags.Attributes.Flags.EditTypes;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Flags
{
    public class FlagsEdit : EditBase
    {
        public FlagsEdit() : this(new FlagsAddition(""))
        {
        }

        public FlagsEdit(EditType editType)
        {
            this.EditType = editType;
        }

        [XmlElement(typeof(EditType))]
        [XmlElement(typeof(FlagsAddition))]
        [XmlElement(typeof(FlagsCalculator))]
        [XmlElement(typeof(FlagsOverWriter))]
        [XmlElement(typeof(FlagsReplacer))]
        public EditType EditType;

        protected override bool RunEdit(UtauElement elm)
        {
            elm.SetFlagsList(EditType.Edit(elm.GetFlagsList()));
            return true;
        }

        override public string ToString()
        {
            return "Flags" + EditType.ToString();
        }

        public override EditControl CreateControl()
        {
            return new FlagsEditControl(this);
        }
    }
}