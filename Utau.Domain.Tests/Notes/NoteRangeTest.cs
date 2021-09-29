using NUnit.Framework;

namespace Utau.Domain.Notes.Tests
{
    [TestFixture]
    internal class NoteRangeTest
    {
        [Test]
        public void 利用可能な音階全てを取得する()
        {
            var range = new NoteRange();
            var list = range.CreateAllNoteList();
            // 昇順で取得される
            Assert.AreEqual(-1, list.IndexOf(Note.ByNoteNumber(23)));
            Assert.AreEqual(0, list.IndexOf(Note.ByNoteNumber(24)));
            Assert.AreEqual(83, list.IndexOf(Note.ByNoteNumber(107)));
            Assert.AreEqual(-1, list.IndexOf(Note.ByNoteNumber(108)));
        }
    }
}