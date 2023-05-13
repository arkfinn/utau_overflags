using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utau.Domain.Scores;
using Utau.Elements;

namespace Utau.Infrastructure.ScoreFiles
{
    public class ScoreFileReader : IScoreReader
    {
        public ScoreFileReader(string filepath)
        {
            Filepath = filepath;
        }

        private string Filepath { get; }

        public void Read(Action<UtauElement> callback)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (StreamReader sr = new StreamReader(Filepath, Encoding.GetEncoding("Shift_JIS")))
            {
                var line = "";
                var blockName = "";
                var values = new Dictionary<string, string>();
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "") continue;
                    if (line.StartsWith("["))
                    {
                        if (IsNoteElement(blockName))
                        {
                            callback(new UtauElement(blockName, values));
                        }
                        blockName = line;
                        values = new Dictionary<string, string>();
                    }
                    else if (line.Contains("="))
                    {
                        string[] v = line.Split(new char[] { '=' });
                        values.Add(v[0], v[1]);
                    }
                }
                if (IsNoteElement(blockName))
                {
                    callback(new UtauElement(blockName, values));
                }
            }
        }

        private static bool IsNoteElement(string blockName)
        {
            // VERSIONelement, SETTINGelementが存在するが、一旦忘れる。
            return blockName != "" && blockName != "[#SETTING]" && blockName != "[#VERSION]";
        }
    }
}