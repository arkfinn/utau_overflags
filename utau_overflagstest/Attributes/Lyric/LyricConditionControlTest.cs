using NUnit.Extensions.Forms;
using NUnit.Framework;
using System.Windows.Forms;
using Utau.Elements;
using utau_overflags.Attributes.Lyric.WordLikes;

namespace utau_overflags.Attributes.Lyric
{
    internal class LyricConditionControlTest
    {
        [Test]
        public void 何もしない時はisChangedがfalse()
        {
            LyricConditionControl control = new LyricConditionControl();
            Assert.That(control.IsChanged, Is.False);
        }

        [Test]
        public void テキストを変更するとIsChangedがONになる()
        {
            LyricConditionControl control = new LyricConditionControl();
            TextBoxTester text = CreateTextBoxTester(CreateForm(control));
            text.Enter("aaa");
            Assert.That(control.IsChanged, Is.True);
        }

        [Test]
        public void プルダウンを変更するとIsChangedがONになる()
        {
            LyricConditionControl control = new LyricConditionControl();
            ComboBoxTester combo = CreateComboBoxTester(CreateForm(control));
            combo.Select(1);
            Assert.That(control.IsChanged, Is.True);
        }

        [TestCase(0, "完全一致")]
        [TestCase(1, "部分一致")]
        [TestCase(2, "前方一致")]
        [TestCase(3, "後方一致")]
        public void テキストを変更すると取得されるWordCondに反映される(int index, string method)
        {
            LyricConditionControl control = new LyricConditionControl();
            Form form = CreateForm(control);
            CreateTextBoxTester(form).Enter("あい");
            CreateComboBoxTester(form).Select(index);

            var cond = control.Export();
            Assert.That(cond.ToString(), Is.EqualTo("「あい」と" + method));
        }

        [Test]
        public void WordConditionを読み込ませるとテキストに反映される()
        {
            LyricConditionControl control = new LyricConditionControl();
            Form form = CreateForm(control);

            LyricCondition cond = new LyricCondition(new ForwardMatching("aaa"));
            control.Import(cond);

            Assert.That(CreateTextBoxTester(form).Text, Is.EqualTo("aaa"));
            Assert.That(CreateComboBoxTester(form).Properties.SelectedIndex, Is.EqualTo(2));
            //読み込み直後は「変更無し」
            Assert.That(control.IsChanged, Is.False);
        }

        private UtauElement createElement(string value)
        {
            UtauElement elm = new UtauElement();
            elm.Lyric = value;
            return elm;
        }

        public TextBoxTester CreateTextBoxTester(Form form)
        {
            return new TextBoxTester("WordConditionControl.textWord", form);
        }

        public ComboBoxTester CreateComboBoxTester(Form form)
        {
            return new ComboBoxTester("WordConditionControl.comboWordLike", form);
        }

        private Form CreateForm(LyricConditionControl control)
        {
            Form form = new Form();
            form.Controls.Add(control);
            return form;
        }
    }
}