using Utau.Elements;

namespace Utau.OverFlags.Domain.Attributes.Vibrato
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

    }
}