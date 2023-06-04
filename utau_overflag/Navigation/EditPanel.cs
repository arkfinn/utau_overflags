using System;
using System.Windows.Forms;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Lyric;
using Utau.OverFlags.Domain.Attributes.Moduration;
using Utau.OverFlags.Domain.Attributes.Intensity;
using Utau.OverFlags.Domain.Attributes.Flags;
using Utau.OverFlags.Domain.Attributes.Vibrato;
using Utau.OverFlags.Domain.Attributes.Others;
using Utau.OverFlags.Domain.Attributes.Note;

namespace utau_overflags.Forms
{
    public partial class EditPanel : UserControl
    {
        public EditPanel()
        {
            InitializeComponent();
        }

        public event EventHandler<EditEventArgs> OnButtonClicked = (s, e) => { };
        private void invokeButtonClicked(EditBase condition)
        {
            OnButtonClicked.Invoke(this, new EditEventArgs(condition));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            invokeButtonClicked(new FlagsEdit());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            invokeButtonClicked(new IntensityEdit());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            invokeButtonClicked(new ModurationEdit());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            invokeButtonClicked(new LyricEdit());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            invokeButtonClicked(new VbrEdit());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            invokeButtonClicked(new OthersEdit());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            invokeButtonClicked(new NoteEdit());
        }
    }

    public class EditEventArgs : EventArgs
    {
        public readonly EditBase Edit;

        public EditEventArgs(EditBase condition)
        {
            Edit = condition;
        }
    }
}
