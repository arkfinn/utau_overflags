using System;
using System.Windows.Forms;
using Utau.Domain.Scores;
using Utau.Infrastructure.ScoreFiles;

namespace utau_overflags
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (0 < args.Length)
            {
                var filepath = args[0];
                var form = new Form1
                {
                    Score = new UtauScore(new ScoreFileWriter(filepath), new ScoreFileReader(filepath))
                };
                Application.Run(form);
            }
        }
    }
}