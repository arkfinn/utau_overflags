using System;
using System.Drawing;
using System.Windows.Forms;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Flags;
using Utau.OverFlags.Domain.Attributes.Intensity;
using Utau.OverFlags.Domain.Attributes.Length;
using Utau.OverFlags.Domain.Attributes.Lyric;
using Utau.OverFlags.Domain.Attributes.Moduration;
using Utau.OverFlags.Domain.Attributes.Note;
using Utau.OverFlags.Domain.Attributes.Others;
using Utau.OverFlags.Domain.Attributes.Vibrato;
using utau_overflags.Attributes.Flags;
using utau_overflags.Attributes.Intensity;
using utau_overflags.Attributes.Length;
using utau_overflags.Attributes.Lyric;
using utau_overflags.Attributes.Moduration;
using utau_overflags.Attributes.Note;
using utau_overflags.Attributes.Others;
using utau_overflags.Attributes.Vibrato;
using utau_overflags.Forms;

namespace utau_overflags.DataEntry.Attributes
{
    internal class EditControlProvider
    {
        public EditControlProvider(EditBase item)
        {
            Control = Provide(item);
        }

        private readonly EditControl Control;

        private EditControl Provide(EditBase item)
        {
            return item.GetType().Name switch
            {
                nameof(FlagsEdit) => new FlagsEditControl(item as FlagsEdit),
                nameof(IntensityEdit) => new IntensityEditControl(item as IntensityEdit),
                nameof(LengthEdit) => new LengthEditControl(item as LengthEdit),
                nameof(LyricEdit) => new LyricEditControl(item as LyricEdit),
                nameof(ModurationEdit) => new ModurationEditControl(item as ModurationEdit),
                nameof(NoteEdit) => new NoteEditControl(item as NoteEdit),
                nameof(OthersEdit) => new OthersEditControl(item as OthersEdit),
                nameof(VbrEdit) => new VbrEditControl(item as VbrEdit),
                _ => throw new ArgumentException(item.GetType().Name),
            };
        }

        public EditBase Call(string title)
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
