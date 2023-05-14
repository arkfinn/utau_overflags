using System.Xml.Serialization;
using Utau.Domain.Notes;
using Utau.Elements;
using Utau.OverFlags.Domain.CalculateCommands;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Note
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

        public override EditControl CreateControl()
        {
            return new NoteEditControl(this);
        }
    }
}