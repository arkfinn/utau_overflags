using System.Collections.Generic;
using System.Linq;

namespace Utau.Domain.Notes
{
    public class NoteRange
    {
        public static readonly int Min = 24;
        public static readonly int Max = 107;

        public IList<Note> CreateAllNoteList()
        {
            List<Note> noteList = new List<Note>();
            foreach (int i in Enumerable.Range(Min, Max - Min + 1))
            {
                noteList.Add(Note.ByNoteNumber(i));
            }
            return noteList;
        }
    }
}