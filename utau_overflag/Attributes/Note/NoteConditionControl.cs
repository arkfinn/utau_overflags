using System;
using Utau.OverFlags.Application;
using utau_overflags.Conditions;

namespace utau_overflags.Attributes.Note
{
    public partial class NoteConditionControl : ConditionControl
    {
        private readonly ComparerPreparation comparation = new ComparerPreparation();

        public NoteConditionControl()
        {
            InitializeComponent();
            InitializeComboNote();
            InitializeComboBox(comboComparer, comparation.CreateParser());
            AnnualChanged();
        }

        public NoteConditionControl(NoteCondition condition) : this()
        {
            Import(condition);
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

        public override CondBase Export()
        {
            return new NoteCondition(comparation.CreateComparer(comboComparer, FetchNoteValue()));
        }

        public void Import(NoteCondition cond)
        {
            comboNote.SelectedValue = cond.Comparer.Value;
            comboComparer.SelectedItem = cond.Comparer.Method;
            AnnualChanged();
        }

        public override void Import(CondBase cond)
        {
            if (cond.GetType() != typeof(NoteCondition))
                throw new ArgumentException();

            Import((NoteCondition)cond);
        }
    }
}