using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Others
{
    public partial class OthersEditControl : EditControl
    {
        public OthersEditControl()
        {
            InitializeComponent();
        }

        public OthersEditControl(OthersEdit edit)
            : this()
        {
            Import(edit);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NotifyChanged();
        }

        public override EditBase Export()
        {
            OthersEdit edit = new OthersEdit(comboKey.Text, textValue.Text);
            edit.Enabled = true;
            return edit;
        }

        public override void Import(EditBase edit)
        {
            if (edit.GetType() != typeof(OthersEdit))
                throw new ArgumentException();

            Import((OthersEdit)edit);
        }

        public void Import(OthersEdit edit)
        {
            comboKey.Text = edit.Key;
            textValue.Text = edit.Value;
            AnnualChanged();
        }

        private void comboKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            NotifyChanged();
        }
    }
}
