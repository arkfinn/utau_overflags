using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Conditions;
using utau_overflags.Attributes.Note;
using utau_overflags.Attributes.Intensity;
using utau_overflags.Attributes.Length;
using utau_overflags.Attributes.Lyric;

namespace utau_overflags.Forms
{
    public partial class ConditionPanel : UserControl
    {
        public ConditionPanel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            invokeButtonClicked(new NoteCondition());
        }

        public event EventHandler<ConditionEventArgs> OnButtonClicked = (s, e) => { };
        private void invokeButtonClicked(CondBase condition)
        {
            OnButtonClicked.Invoke(this, new ConditionEventArgs(condition));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            invokeButtonClicked(new IntensityCondition());
        }

        private void button4_Click(object sender, EventArgs e)
        {

            invokeButtonClicked(new LengthCondition());
        }

        private void button5_Click(object sender, EventArgs e)
        {

            invokeButtonClicked(new LyricCondition());
        }

    }

    public class ConditionEventArgs:EventArgs
    {
        public readonly CondBase Condition;
        public ConditionEventArgs(CondBase condition)
        {
            Condition = condition;
        }
    }
}
