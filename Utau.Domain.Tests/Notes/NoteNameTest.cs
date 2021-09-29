using NUnit.Framework;
using System;

namespace Utau.Domain.Notes.Tests
{
    internal class NoteNameTest
    {
        [Test]
        public void 例外のテスト()
        {
            var ex = Assert.Throws<ArgumentException>(() => new NoteName(-1));
        }
    }
}