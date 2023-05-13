using System;
using System.IO;
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

            string filepath;
#if DEBUG
            // デバッグモードでは一時ファイルを用いてGUIのテストができる
            filepath = Path.GetTempFileName();
#else
            if (args.Length <= 0)
            {
                return;
            }
            filepath = args[0];
#endif
            try
            {
                var form = new Form1
                {
                    Score = new UtauScore(new ScoreFileWriter(filepath), new ScoreFileReader(filepath))
                };
                Application.Run(form);
            }
            finally
            {
#if DEBUG
                // デバッグ用一時ファイルの削除
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
#endif
            }
        }
    }
}