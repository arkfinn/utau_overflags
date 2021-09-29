using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utau.Elements;

namespace Utau.Domain.Scores
{
    public class UtauScore
    {
        static public void setup(IScoreWriter writer, IScoreReader reader)
        {
            instance = new UtauScore(writer, reader);
        }

        static private UtauScore instance;

        static public UtauScore getInstance()
        {
            if (instance == null)
            {
                throw new ApplicationException("必ずsetupを行って下さい");
            }
            return instance;
        }

        public UtauElement SettingElement;
        private List<UtauElement> mElements;

        protected List<UtauElement> Elements
        {
            get
            {
                if (mElements == null)
                {
                    mElements = new List<UtauElement>();
                }
                return mElements;
            }
        }

        // 一時的措置
        private IScoreWriter Writer;

        private IScoreReader Reader;

        public UtauScore(IScoreWriter writer, IScoreReader reader)
        {
            Writer = writer;
            Reader = reader;

            Reader.Read((StreamReader sr) =>
            {
                string line = "";
                UtauElement elm = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        continue;
                    }
                    else if (line.StartsWith("["))
                    {
                        elm = new UtauElement(line);
                        if (line == "[#SETTING]")
                        {
                            SettingElement = elm;
                        }
                        else
                        {
                            Elements.Add(elm);
                        }
                    }
                    else if (line.Contains("="))
                    {
                        string[] v = line.Split(new char[] { '=' });
                        elm.Values.Add(v[0], v[1]);
                    }

                    //                    form.textBox1.AppendText(line);
                    //                  form.textBox1.AppendText(Environment.NewLine);
                }
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