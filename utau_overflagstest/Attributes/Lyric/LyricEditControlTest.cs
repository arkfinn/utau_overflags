using NUnit.Extensions.Forms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Attributes;
using utau_overflags.Attributes.Lyric;
using utau_overflags.Attributes.Lyric.Connectors;

namespace utau_overflagstest.Attributes.Word
{
    class LyricEditControlTest
    {
        #region isChanged関連
        [Test]
        public void 何もしない時はisChangedがfalse()
        {
            ChangableControl control = CreateControl();
            Assert.That(control.IsChanged, Is.False);
        }

        [Test]
        public void テキストを変更するとIsChangedがONになる()
        {
            ChangableControl control = CreateControl();
            CreateTextBoxTester(CreateForm(control)).Enter("aaa");
            Assert.That(control.IsChanged, Is.True);
        }

        [Test]
        public void プルダウンを変更するとIsChangedがONになる()
        {
            ChangableControl control = CreateControl();
            CreateComboBoxTester(CreateForm(control)).Select(1);
            Assert.That(control.IsChanged, Is.True);
        }
        #endregion

        [TestCase(0, "セット")]
        [TestCase(1, "前に追加")]
        [TestCase(2, "後に追加")]
        public void テキストを変更すると取得されるWordEditに反映される(int index, string method)
        {
            LyricEditControl control = new LyricEditControl();

            Form form = CreateForm(control);
            CreateTextBoxTester(form).Enter("あ");
            CreateComboBoxTester(form).Select(index);

            Assert.That(control.Export().ToString(), Is.EqualTo("歌詞に「あ」を"+method));
       }

        [Test]
        public void WordEditを読み込ませるとフォームに反映される()
        {
            LyricEditControl control = new LyricEditControl();
            Form form = CreateForm(control);

            LyricEdit cond = new LyricEdit(new SuffixConnector("aaa"));
            control.Import(cond);

            Assert.That(CreateTextBoxTester(form).Text, Is.EqualTo("aaa"));
            Assert.That(CreateComboBoxTester(form).Properties.SelectedIndex, Is.EqualTo(2));
            //読み込み直後は「変更無し」
            Assert.That(control.IsChanged, Is.False);
        }

        private LyricEditControl CreateControl()
        {
            return new LyricEditControl();
        }

        public TextBoxTester CreateTextBoxTester(Form form)
        {
            return new TextBoxTester("WordEditControl.textWord", form);
        }

        public ComboBoxTester CreateComboBoxTester(Form form)
        {
            return new ComboBoxTester("WordEditControl.comboWordConnect", form);
        }

        private Form CreateForm(UserControl control)
        {
            Form form = new Form();
            form.Controls.Add(control);
            return form;
        }
    }
}
