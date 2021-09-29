namespace Utau.Domain.Notes
{
    public class Note
    {
        //public Note() : this(0)
        //{
        //    //UIのための実装だったと思う。意図がわかんないのでExceptionしておく
        //    throw new Exception("Note nazo jissou");
        //}

        private Note(int noteNumber)
        {
            NoteNumber = noteNumber;
            NoteName = new NoteName(noteNumber);
            Octave = CalculateOctave(noteNumber);
        }

        public static Note ByNoteNumber(int noteNumber)
        {
            return new Note(noteNumber);
        }

        public int NoteNumber { get; }
        private int Octave { get; }
        private readonly NoteName NoteName;

        private int CalculateOctave(int num)
        {
            return (num - 12) / 12;
        }

        public string NameOctave
        {
            get { return NoteName.Value + Octave.ToString(); }
        }

        public override string ToString()
        {
            return NameOctave;
        }

        public override bool Equals(object obj)
        {
            return obj is Note note && NoteNumber == note.NoteNumber;
        }

        public override int GetHashCode()
        {
            return 727944056 + NoteNumber.GetHashCode();
        }
    }
}