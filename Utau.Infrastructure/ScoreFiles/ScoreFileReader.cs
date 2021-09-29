using System;
using System.IO;
using System.Text;
using Utau.Domain.Scores;

namespace Utau.Infrastructure.ScoreFiles
{
    public class ScoreFileReader : IScoreReader
    {
        public ScoreFileReader(string filepath)
        {
            Filepath = filepath;
        }

        private string Filepath { get; }

        public void Read(Action<StreamReader> callback)
        {
            using (StreamReader sr = new StreamReader(Filepath, Encoding.GetEncoding("Shift_JIS")))
            {
                callback(sr);
            }
        }
    }
}