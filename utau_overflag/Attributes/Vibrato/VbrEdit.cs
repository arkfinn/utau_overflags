using Utau.Elements;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Vibrato
{
    public class VbrEdit : EditBase
    {
        public VbrEdit(string vbr)
        {
            Vbr = vbr;
        }

        public VbrEdit() : this("")
        {
        }

        public string Vbr;

        override protected bool RunEdit(UtauElement elm)
        {
            elm["VBR"] = Vbr;
            return true;
        }

        override public string ToString()
        {
            return "VBRに「" + Vbr + "」を設定";
        }

        public override EditControl CreateControl()
        {
            return new VbrEditControl(this);
        }
    }
}