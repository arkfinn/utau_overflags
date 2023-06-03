using System;
using utau_overflags.Edits;
using Utau.OverFlags.Domain.Commands.Flags;
using Utau.OverFlags.Domain.Choices;
using Utau.OverFlags.Domain.Attributes.Flags;
using Utau.OverFlags.Domain.Attributes;

namespace utau_overflags.Attributes.Flags
{
    public partial class FlagsEditControl : EditControl
    {
        public FlagsEditControl()
        {
            InitializeComponent();
            InitializeComboBox(comboEditType, new EditTypeChoice());
        }

        public FlagsEditControl(FlagsEdit edit)
            : this()
        {
            Import(edit);
        }

        private void formChanged(object sender, EventArgs e)
        {
            NotifyChanged();
        }

        public override EditBase Export()
        {
            FlagsEdit edit = new FlagsEdit(CreateEditType((string)comboEditType.SelectedItem, textFlags.Text));
            edit.Enabled = true;
            return edit;
        }

        private FlagsCommand CreateEditType(string method, string word)
        {
            EditTypeChoice parser = new EditTypeChoice();
            return parser.Parse(method, word);
        }

        public override void Import(EditBase edit)
        {
            if (edit.GetType() != typeof(FlagsEdit))
                throw new ArgumentException();

            Import((FlagsEdit)edit);
        }

        public void Import(FlagsEdit edit)
        {
            textFlags.Text = edit.EditType.Plan.ToString();
            comboEditType.SelectedItem = edit.EditType.Method;
            AnnualChanged();
        }
    }
}
