using NUnit.Extensions.Forms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Attributes;
using utau_overflags.Attributes.Flags.EditTypes;
using utau_overflagstest.Attributes;

namespace utau_overflags.Attributes.Flags
{
    class FlagsEditControlTest : ControlTestBase
    {
        #region isChanged関連
        [Test]
        public void 何もしない時はisChangedがfalse()
        {
            ChangableControl control = CreateControl();
            Assert.That(control.IsChanged, Is.False);
        }

        [Test]
        public void Textboxを変更するとIsChangedがONになる()
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

        [TestCase(0, "を追加")]
        [TestCase(1, "で上書き")]
        [TestCase(2, "で置換")]
        [TestCase(3, "で計算")]
        public void フォームを変更すると取得されるFlagsEditに反映される(int index, string method)
        {
            FlagsEditControl control = CreateControl();
            Form form = CreateForm(control);
            CreateTextBoxTester(form).Enter("B10");
            CreateComboBoxTester(form).Select(index);

            Assert.That(control.Export().ToString(), Is.EqualTo("Flags「B10」" + method));
        }

        [Test]
        public void FlagsEditを読み込ませるとフォームに反映される()
        {
            FlagsEditControl control = CreateControl();
            Form form = CreateForm(control);

            control.Import(new FlagsEdit(new FlagsReplacer("B10")));

            Assert.That(CreateTextBoxTester(form).Text, Is.EqualTo("B10"));
            Assert.That(CreateComboBoxTester(form).Properties.SelectedIndex, Is.EqualTo(2));
            //読み込み直後は「変更無し」
            Assert.That(control.IsChanged, Is.False);
        }

        private FlagsEditControl CreateControl()
        {
            return new FlagsEditControl();
        }

        public TextBoxTester CreateTextBoxTester(Form form)
        {
            return new TextBoxTester("FlagsConditionControl.textFlags", form);
        }

        public ComboBoxTester CreateComboBoxTester(Form form)
        {
            return new ComboBoxTester("FlagsConditionControl.comboEditType", form);
        }
    }
}
