using NUnit.Framework;
using System.IO;
using Utau.Domain.Scores;

namespace Utau.Infrastructure.ScoreFiles
{
    [TestFixture()]
    public class ScoreFileWriterTests
    {
        [TestCase("1_before.txt", "1_after.txt", "1_after_expected.txt")]
        public void WriteTest(string beforeFilename, string afterFilename, string expectedFilename)
        {
            var currentPath = Directory.GetCurrentDirectory() + "\\ScoreFiles\\TestFiles\\";
            var inpath = currentPath + beforeFilename;
            var outpath = currentPath + afterFilename;
            var expectedpath = currentPath + expectedFilename;
            var reader = new ScoreFileReader(inpath);
            var writer = new ScoreFileWriter(outpath);
            var score = new UtauScore(writer, reader);
            score.output();
            Assert.AreEqual(File.ReadAllText(expectedpath), File.ReadAllText(outpath));
        }
    }
}