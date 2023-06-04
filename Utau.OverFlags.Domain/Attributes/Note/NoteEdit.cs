using System.Xml.Serialization;
using Utau.Elements;

namespace Utau.OverFlags.Domain.Attributes.Note
{
    public class NoteEdit : EditBase
    {
        public NoteEdit() : this(60)
        {
        }

        public NoteEdit(int noteNumber)
        {
            NoteNum = noteNumber;
        }

        [XmlElement("NoteNum")]
        public int NoteNum;

        override protected bool RunEdit(UtauElement elm)
        {
            elm.NoteNum = NoteNum;
            return true;
        }

        override public string ToString()
        {
            return "音階を"+Utau.Domain.Notes.Note.ByNoteNumber(NoteNum).ToString() + "に変更";
        }

    }
}