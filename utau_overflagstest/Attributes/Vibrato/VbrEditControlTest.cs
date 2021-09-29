using NUnit.Extensions.Forms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Vibrato
{
    class VbrEditFormTest
    {
        [Test]
        public void 何もしない時はisChangedがfalse()
        {
            Assert.That(CreateControl().IsChanged, Is.False);
        }

        [Test]
        public void テキストを変更するとIsChangedがONになる()
        {
            VbrEditControl control = CreateControl();
            CreateTextBoxTester(control).Enter("aaa");
            Assert.That(control.IsChanged, Is.True);
        }
  
        [Test]
        public void テキストを変更すると取得されるVbrEditに反映される()
        {
            VbrEditControl control = CreateControl();

            CreateTextBoxTester(control).Enter("あいうえ");
            VbrEdit edit = (VbrEdit)control.Export();

            Assert.That(edit.Vbr, Is.EqualTo("あいうえ"));
        }

        [Test]
        public void VbrEditを読み込ませるとテキストに反映される()
        {
            VbrEditControl control = CreateControl();
            VbrEdit edit = new VbrEdit("1,2,3,4");
            control.Import(edit);

            Assert.That(CreateTextBoxTester(control).Text, Is.EqualTo("1,2,3,4"));
            //読み込み直後は「変更無し」
            Assert.That(control.IsChanged, Is.False);
        }

        public VbrEditControl CreateControl()
        {
            return new VbrEditControl();
        }

        public TextBoxTester CreateTextBoxTester(VbrEditControl control)
        {
            Form form = new Form();
            form.Controls.Add(control);
            return new TextBoxTester("VbrEditControl.textVbr", form);
        }
    }
}
