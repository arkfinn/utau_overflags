using System.IO;
using System.Text;
using Utau.Domain.Scores;

namespace Utau.Infrastructure.ScoreFiles
{
    public class ScoreFileWriter : IScoreWriter
    {
        readonly private string Filepath;

        public ScoreFileWriter(string filepath)
        {
            Filepath = filepath;
        }

        public void Write(string body)
        {
            using (StreamWriter writer = new StreamWriter(Filepath, false, Encoding.GetEncoding("Shift_JIS")))
            {
                writer.Write(body);
            }
        }
    }
}