using NUnit.Framework;
using Utau.Domain.Notes;

namespace Utau.OverFlags.Application.Tests
{
    [TestFixture]
    internal class PrepareNoteDataSourceTest
    {
        [Test]
        public void 利用可能な音階全てを取得する()
        {
            var usecase = new PrepareNoteDataSource();
            var list = usecase.CreateNoteList();
            // 降順で取得される
            Assert.AreEqual(-1, list.IndexOf(Note.ByNoteNumber(23)));
            Assert.AreEqual(83, list.IndexOf(Note.ByNoteNumber(24)));
            Assert.AreEqual(0, list.IndexOf(Note.ByNoteNumber(107)));
            Assert.AreEqual(-1, list.IndexOf(Note.ByNoteNumber(108)));
        }

        [Test]
        public void ValueMemberがNoteのプロパティ名と一致すること()
        {
            var usecase = new PrepareNoteDataSource();
            Assert.AreEqual(nameof(Note.NoteNumber), usecase.ValueMember);
        }

        [Test]
        public void DisplayMemberがNoteのプロパティ名と一致すること()
        {
            var usecase = new PrepareNoteDataSource();
            Assert.AreEqual(nameof(Note.NameOctave), usecase.DisplayMember);
        }
    }
}