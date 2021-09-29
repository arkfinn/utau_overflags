using System.Collections.Generic;
using System.Linq;
using Utau.Domain.Notes;

namespace Utau.OverFlags.Application
{
    public class PrepareNoteDataSource
    {
        public readonly string ValueMember = nameof(Note.NoteNumber);
        public readonly string DisplayMember = nameof(Note.NameOctave);

        public IList<Note> CreateNoteList()
        {
            var range = new NoteRange();
            var noteList = range.CreateAllNoteList();
            return Enumerable.Reverse(noteList).ToList();
        }
    }
}