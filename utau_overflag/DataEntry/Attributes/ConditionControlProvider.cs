using System;
using System.Drawing;
using System.Windows.Forms;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Intensity;
using Utau.OverFlags.Domain.Attributes.Length;
using Utau.OverFlags.Domain.Attributes.Lyric;
using Utau.OverFlags.Domain.Attributes.Note;
using utau_overflags.Attributes.Intensity;
using utau_overflags.Attributes.Length;
using utau_overflags.Attributes.Lyric;
using utau_overflags.Attributes.Note;
using utau_overflags.Forms;

namespace utau_overflags.DataEntry.Attributes
{
    internal class ConditionControlProvider
    {
        public ConditionControlProvider(CondBase item)
        {
            Control = Provide(item);
        }

        private readonly ConditionControl Control;

        private ConditionControl Provide(CondBase item)
        {
            return item.GetType().Name switch
            {
                nameof(IntensityCondition) => new IntensityConditionControl(item as IntensityCondition),
                nameof(LengthCondition) => new LengthConditionControl(item as LengthCondition),
                nameof(LyricCondition) => new LyricConditionControl(item as LyricCondition),
                nameof(NoteCondition) => new NoteConditionControl(item as NoteCondition),
                _ => throw new ArgumentException(item.GetType().Name),
            };
        }

        public CondBase Call(string title)
        {
            // TODO: このダイアログ用のformを作成
            // ManipulationControlと共通化する
            using var form = new Form();
            form.Text = title;
            form.Size = new Size(400, 160);
            form.StartPosition = FormStartPosition.CenterParent;
            var panel = new EditDialogPanel();
            panel.Dock = DockStyle.Fill;
            panel.AddContents(Control);
            form.Controls.Add(panel);
            form.ShowDialog();
            return form.DialogResult == DialogResult.OK ? Control.Export() : null;
        }
    }
}
