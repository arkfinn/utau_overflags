using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Attributes.Lyric.WordLikes;
using utau_overflags.Conditions;

namespace utau_overflags.Attributes.Lyric
{
    public partial class LyricConditionControl :  ConditionControl
    {
        public LyricConditionControl()
        {
            InitializeComponent();
            InitializeComboBox(comboWordLike, CreateParser());
            AnnualChanged();
        }
        public LyricConditionControl(LyricCondition condition) :this()
        {
            Import(condition);
        }

        private MatchingParser CreateParser()
        {
            return new MatchingParser();
        }

        private void formChanged(object sender, EventArgs e)
        {
            NotifyChanged();
        }

        private Matching CreateMatching(string value)
        {
            return CreateParser().Parse((string)comboWordLike.SelectedItem, value);
        }

        public override CondBase Export()
        {
            LyricCondition cond = new LyricCondition(CreateMatching(textWord.Text));
            cond.Enabled = true;
            return cond;
        }

        public override void Import(CondBase cond)
        {
            if (cond.GetType() != typeof(LyricCondition))
                throw new ArgumentException();

            Import((LyricCondition)cond);
        }

        public void Import(LyricCondition cond)
        {
            textWord.Text = cond.Word;
            comboWordLike.SelectedItem = cond.Matching.Method;
            AnnualChanged();
        }
    }
}
