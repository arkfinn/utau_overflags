using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Utau.OverFlags.Domain.Commands.Connectors;
using Utau.OverFlags.Domain.Choices;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Lyric;
using utau_overflags.DataEntry.Attributes;

namespace utau_overflags.Attributes.Lyric
{
    public partial class LyricEditControl : EditControl
    {
        public LyricEditControl()
        {
            InitializeComponent();
            InitializeComboBox(comboWordConnect, CreateParser());
        }

        public LyricEditControl(LyricEdit edit)
            : this()
        {
            Import(edit);
        }

        private ConnectorChoice CreateParser()
        {
            return new ConnectorChoice();
        }

        private void formChanged(object sender, EventArgs e)
        {
            NotifyChanged();
        }

        private Connector CreateConnector(string method, string word)
        {
            return CreateParser().Parse(method, word);
        }

        public override EditBase Export()
        {
            LyricEdit edit = new LyricEdit(CreateConnector((string)comboWordConnect.SelectedItem, textWord.Text));
            edit.Enabled = true;
            return edit;
        }

        public override void Import(EditBase edit)
        {
            if (edit.GetType() != typeof(LyricEdit))
                throw new ArgumentException();

            Import((LyricEdit)edit);
        }

        public void Import(LyricEdit cond)
        {
            textWord.Text = cond.WordConnector.Word;
            comboWordConnect.SelectedItem = cond.WordConnector.Method;
            AnnualChanged();
        }
    }
}
