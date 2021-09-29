using NUnit.Extensions.Forms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Attributes;
using utau_overflags.Attributes.Comparers;
using utau_overflags.Attributes.Intensity;
using utau_overflags.Conditions;

namespace utau_overflagstest.Attributes.Intensity
{
    class IntensityConditionControlTest
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
        #endregion

        [TestCase(0, "以上")]
        [TestCase(1, "と同値")]
        [TestCase(2, "以下")]
        public void テキストを変更すると取得されるIntensityCondに反映される(int index, string method)
        {
            IntensityConditionControl control = CreateControl();
            Form form = CreateForm(control);
            CreateUpDownTester(form).Value = 1;
            CreateComboBoxTester(form).Select(index);

            Assert.That(control.Export().ToString(), Is.EqualTo("音量が1" + method));
        }

        [Test]
        public void IntensityConditionを読み込ませるとテキストに反映される()
        {
            IntensityConditionControl control = CreateControl();
            Form form = CreateForm(control);

            control.Import(new IntensityCondition(new LessThanEqualsComparer(1)));

            Assert.That(CreateUpDownTester(form).Value, Is.EqualTo(1));
            Assert.That(CreateComboBoxTester(form).Properties.SelectedIndex, Is.EqualTo(2));
            //読み込み直後は「変更無し」
            Assert.That(control.IsChanged, Is.False);
        }

        private IntensityConditionControl CreateControl()
        {
            return new IntensityConditionControl();
        }

        public NumericUpDown CreateUpDownTester(Form form)
        {
             ControlFinder finder = new ControlFinder("IntensityConditionControl.numIntensity", form);
             return (NumericUpDown)finder.Find();
        }

        public ComboBoxTester CreateComboBoxTester(Form form)
        {
            return new ComboBoxTester("IntensityConditionControl.comboComparer", form);
        }

        private Form CreateForm(UserControl control)
        {
            Form form = new Form();
            form.Controls.Add(control);
            return form;
        }
    }
}
