using NUnit.Framework;

namespace Utau.Domain.Notes.Tests
{
    [TestFixture]
    public class NoteTst
    {
        [TestCase(24, "C1")]
        [TestCase(65, "F4")]
        public void ノート番号から音階名に変換できる(int given, string then)
        {
            Assert.AreEqual(then, Note.ByNoteNumber(given).ToString());
        }

        [Test]
        public void ふたつのNoteが同じ()
        {
            Assert.That(Note.ByNoteNumber(60), Is.EqualTo(Note.ByNoteNumber(60)));
        }

        [Test]
        public void ふたつのNoteのhashが同じ()
        {
            Assert.That(Note.ByNoteNumber(60).GetHashCode(), Is.EqualTo(Note.ByNoteNumber(60).GetHashCode()));
        }
    }
}