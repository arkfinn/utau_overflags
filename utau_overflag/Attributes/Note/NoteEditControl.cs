using System;
using Utau.OverFlags.Application;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Note;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Note
{
    public partial class NoteEditControl : EditControl
    {
        private readonly ComparerPreparation comparation = new ComparerPreparation();

        public NoteEditControl()
        {
            InitializeComponent();
            InitializeComboNote();
        }

        public NoteEditControl(NoteEdit edit)
            : this()
        {
            Import(edit);
        }

        private void InitializeComboNote()
        {
            var usecase = new PrepareNoteDataSource();
            comboNote.DataSource = usecase.CreateNoteList();
            comboNote.ValueMember = usecase.ValueMember;
            comboNote.DisplayMember = usecase.DisplayMember;
        }

        private void formChanged(object sender, EventArgs e)
        {
            NotifyChanged();
        }

        private int FetchNoteValue()
        {
            return ((Utau.Domain.Notes.Note)comboNote.SelectedItem).NoteNumber;
        }

        public override EditBase Export()
        {
            return new NoteEdit(FetchNoteValue());
        }

        public override void Import(EditBase edit)
        {
            if (edit.GetType() != typeof(NoteEdit))
                throw new ArgumentException();

            Import((NoteEdit)edit);
        }

        public void Import(NoteEdit edit)
        {
            comboNote.SelectedItem = edit.NoteNum;
            AnnualChanged();
        }
    }
}