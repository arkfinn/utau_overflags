using NUnit.Framework;
using Utau.Elements;

namespace Utau.OverFlags.Domain.Attributes.Note
{
    class NoteEditTest
    {
        [Test]
        public void DefaultValueTest()
        {
            var edit = new NoteEdit();
            Assert.That(edit.NoteNum, Is.EqualTo(60));
        }

        [TestCase(60)]
        [TestCase(61)]
        public void EditTest(int noteNum)
        {
            var elm = new UtauElement();
            var edit = new NoteEdit(noteNum);

            edit.Edit(elm);

            Assert.That(elm.NoteNum, Is.EqualTo(noteNum));
        }

        [TestCase(60, "C4")]
        [TestCase(61, "C#4")]
        public void ToStringTest(int noteNum, string noteLabel) {
            var edit = new NoteEdit(noteNum);
            Assert.That(edit.ToString(), Is.EqualTo($"音階を{noteLabel}に変更"));
        }
    }
}
