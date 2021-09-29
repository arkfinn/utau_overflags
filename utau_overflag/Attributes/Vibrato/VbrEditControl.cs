using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Vibrato
{
    public partial class VbrEditControl : EditControl
    {
        public VbrEditControl()
        {
            InitializeComponent();
        }

        public VbrEditControl(VbrEdit edit)
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
            VbrEdit edit = new VbrEdit(textVbr.Text);
            edit.Enabled = true;
            return edit;
        }

        public override void Import(EditBase edit)
        {
            if (edit.GetType() != typeof(VbrEdit))
                throw new ArgumentException();

            Import((VbrEdit)edit);
        }

        public void Import(VbrEdit edit)
        {
            textVbr.Text = edit.Vbr;
            AnnualChanged();
        }
    }
}
