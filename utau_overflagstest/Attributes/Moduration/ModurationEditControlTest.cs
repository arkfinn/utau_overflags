using NUnit.Extensions.Forms;
using NUnit.Framework;
using System.Windows.Forms;
using Utau.OverFlags.Domain.CalculateCommands;
using utau_overflags.Attributes.Moduration;

namespace utau_overflags.Attributes.Intensity
{
    internal class ModurationEditControlTest
    {
        #region isChanged関連

        [Test]
        public void 何もしない時はisChangedがfalse()
        {
            ChangableControl control = CreateControl();
            Assert.That(control.IsChanged, Is.False);
        }

        [Test]
        public void UpDownを変更するとIsChangedがONになる()
        {
            ChangableControl control = CreateControl();
            CreateUpDownTester(CreateForm(control)).Value = 100;
            Assert.That(control.IsChanged, Is.True);
        }

        [Test]
        public void プルダウンを変更するとIsChangedがONになる()
        {
            ChangableControl control = CreateControl();
            CreateComboBoxTester(CreateForm(control)).Select(1);
            Assert.That(control.IsChanged, Is.True);
        }

        #endregion isChanged関連

        [TestCase(0, "に設定")]
        [TestCase(1, "加算")]
        [TestCase(2, "減算")]
        [TestCase(3, "%に変更")]
        public void フォームを変更するとExportされるModurationEditに反映される(int index, string method)
        {
            ModurationEditControl control = CreateControl();
            Form form = CreateForm(control);
            CreateUpDownTester(form).Value = 1;
            CreateComboBoxTester(form).Select(index);

            Assert.That(control.Export().ToString(), Is.EqualTo("モジュレーションを1" + method));
        }

        [Test]
        public void ModurationEditをImportするとフォームに反映される()
        {
            ModurationEditControl control = CreateControl();
            Form form = CreateForm(control);

            control.Import(new ModurationEdit(new SubtractionCommand(1)));

            Assert.That(CreateUpDownTester(form).Value, Is.EqualTo(1));
            Assert.That(CreateComboBoxTester(form).Properties.SelectedIndex, Is.EqualTo(2));
            //読み込み直後は「変更無し」
            Assert.That(control.IsChanged, Is.False);
        }

        private ModurationEditControl CreateControl()
        {
            return new ModurationEditControl();
        }

        public NumericUpDown CreateUpDownTester(Form form)
        {
            ControlFinder finder = new ControlFinder("ModurationEditControl.numModuration", form);
            return (NumericUpDown)finder.Find();
        }

        public ComboBoxTester CreateComboBoxTester(Form form)
        {
            return new ComboBoxTester("ModurationEditControl.comboCalculator", form);
        }

        private Form CreateForm(UserControl control)
        {
            Form form = new Form();
            form.Controls.Add(control);
            return form;
        }
    }
}