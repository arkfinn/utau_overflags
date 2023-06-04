using System;
using System.Windows.Forms;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Note;
using Utau.OverFlags.Domain.Attributes.Intensity;
using Utau.OverFlags.Domain.Attributes.Length;
using Utau.OverFlags.Domain.Attributes.Lyric;

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
