using System.Collections.Generic;
using System.Text;
using Utau.Elements;

namespace Utau.Domain.Scores
{
    public class UtauScore
    {
        public UtauElement SettingElement;

        private List<UtauElement> Elements = new List<UtauElement>();

        // 一時的措置
        private IScoreWriter Writer;

        private IScoreReader Reader;

        public UtauScore(IScoreWriter writer, IScoreReader reader)
        {
            Writer = writer;
            Reader = reader;

            Reader.Read((UtauElement elm) =>
            {
                Elements.Add(elm);
            });
        }

        public void output()
        {
            StringBuilder sb = new StringBuilder();
            foreach (UtauElement v in Elements)
            {
                v.output(sb);
            }

            Writer.Write(sb.ToString());
        }

        public void ElementForEach(UtauElementEventHandler callback)
        {
            int index = 0;

            UtauElement[] list = Elements.ToArray();
            for (int i = 0; i < list.Length; i++)
            {
                UtauElement now = list[i];
                if (now.IsSelected())
                {
                    UtauElement prev = i == 0 ? new UtauElement("[#PREV]") : list[i - 1];
                    UtauElement next = i == list.Length - 1 ? new UtauElement("[#NEXT]") : list[i + 1];
                    callback(index, prev, now, next);
                    index++;
                }
            }
        }

        //public UtauScore Map(UtauScoreCallback callback)
        //{
        //    int index = 0;

        //    UtauElement[] list = Elements.ToArray();
        //    for (int i = 0; i < list.Length; i++)
        //    {
        //        UtauElement now = list[i];
        //        if (now.IsSelected())
        //        {
        //            UtauElement prev = i == 0 ? new UtauElement("[#PREV]") : list[i - 1];
        //            UtauElement next = i == list.Length - 1 ? new UtauElement("[#NEXT]") : list[i + 1];
        //            callback(index, prev, now, next);
        //            index++;
        //        }
        //    }
        //}

        public void InsertBefore(UtauElement elm, UtauElement insert_elm)
        {
            insert_elm.BlockName = "[#INSERT]";
            int index = Elements.IndexOf(elm);
            Elements.Insert(index, insert_elm);
        }

        public UtauElement GetNewElement()
        {
            return new UtauElement();
        }
    }

    public delegate void UtauElementEventHandler(int key, UtauElement prev, UtauElement now, UtauElement next);
}