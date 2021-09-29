using NUnit.Extensions.Forms;
using NUnit.Framework;
using System.Windows.Forms;
using utau_overflags.Attributes;
using utau_overflags.Attributes.Comparers;
using utau_overflags.Attributes.Note;

namespace utau_overflagstest.Attributes.Note
{
    internal class NoteConditionControlTest
    {
        #region isChanged関連

        [Test]
        public void 何もしない時はisChangedがfalse()
        {
            ChangableControl control = CreateControl();
            Assert.That(control.IsChanged, Is.False);
        }

        [Test]
        public void Comparerを変更するとIsChangedがONになる()
        {
            ChangableControl control = CreateControl();
            CreateComboBoxTester(CreateForm(control)).Select(1);
            Assert.That(control.IsChanged, Is.True);
        }

        [Test]
        public void Noteを変更するとIsChangedがONになる()
        {
            ChangableControl control = CreateControl();
            CreateNoteTester(CreateForm(control)).Select(1);
            Assert.That(control.IsChanged, Is.True);
        }

        #endregion isChanged関連

        [TestCase(0, "以上")]
        [TestCase(1, "と同値")]
        [TestCase(2, "以下")]
        public void フォームを変更するとExportされるNoteConditionに反映される(int index, string method)
        {
            NoteConditionControl control = CreateControl();
            Form form = CreateForm(control);
            CreateNoteTester(form).Select(1);
            CreateComboBoxTester(form).Select(index);

            Assert.That(control.Export().ToString(), Is.EqualTo("A#7" + method));
        }

        [Test]
        public void IntensityConditionをImportするとテキストに反映される()
        {
            NoteConditionControl control = CreateControl();
            Form form = CreateForm(control);

            control.Import(new NoteCondition(new LessThanEqualsComparer(50)));

            Assert.That(CreateNoteTester(form).Properties.SelectedItem, Is.EqualTo(Utau.Domain.Notes.Note.ByNoteNumber(50)));
            Assert.That(CreateComboBoxTester(form).Properties.SelectedIndex, Is.EqualTo(2));
            //読み込み直後は「変更無し」
            Assert.That(control.IsChanged, Is.False);
        }

        private NoteConditionControl CreateControl()
        {
            return new NoteConditionControl();
        }

        public ComboBoxTester CreateNoteTester(Form form)
        {
            return new ComboBoxTester("NoteConditionControl.comboNote", form);
        }

        public ComboBoxTester CreateComboBoxTester(Form form)
        {
            return new ComboBoxTester("NoteConditionControl.comboComparer", form);
        }

        private Form CreateForm(UserControl control)
        {
            Form form = new Form();
            form.Controls.Add(control);
            return form;
        }
    }
}