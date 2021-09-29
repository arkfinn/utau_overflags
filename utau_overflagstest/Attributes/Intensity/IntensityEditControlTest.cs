using NUnit.Extensions.Forms;
using NUnit.Framework;
using System.Windows.Forms;
using Utau.OverFlags.Domain.CalculateCommands;

namespace utau_overflags.Attributes.Intensity
{
    internal class IntensityEditControlTest
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
        public void テキストを変更するとExportされるIntensityEditに反映される(int index, string method)
        {
            IntensityEditControl control = CreateControl();
            Form form = CreateForm(control);
            CreateUpDownTester(form).Value = 1;
            CreateComboBoxTester(form).Select(index);

            Assert.That(control.Export().ToString(), Is.EqualTo("音量を1" + method));
        }

        [Test]
        public void IntensityEditをImportするとフォームに反映される()
        {
            IntensityEditControl control = CreateControl();
            Form form = CreateForm(control);

            control.Import(new IntensityEdit(new SubtractionCommand(1)));

            Assert.That(CreateUpDownTester(form).Value, Is.EqualTo(1));
            Assert.That(CreateComboBoxTester(form).Properties.SelectedIndex, Is.EqualTo(2));
            //読み込み直後は「変更無し」
            Assert.That(control.IsChanged, Is.False);
        }

        private IntensityEditControl CreateControl()
        {
            return new IntensityEditControl();
        }

        public NumericUpDown CreateUpDownTester(Form form)
        {
            ControlFinder finder = new ControlFinder("IntensityEditControl.numIntensity", form);
            return (NumericUpDown)finder.Find();
        }

        public ComboBoxTester CreateComboBoxTester(Form form)
        {
            return new ComboBoxTester("IntensityEditControl.comboCalculator", form);
        }

        private Form CreateForm(UserControl control)
        {
            Form form = new Form();
            form.Controls.Add(control);
            return form;
        }
    }
}