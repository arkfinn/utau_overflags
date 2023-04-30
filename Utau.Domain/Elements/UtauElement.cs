using System;
using System.Collections.Generic;
using System.Text;
using Utau.Domain.Flags;
using Utau.Domain.Notes;
using Utau.Domain.PitchBends;

namespace Utau.Elements
{
    public class UtauElement
    {
        public UtauElement()
            : this("[#INSERT]")
        { }

        public string BlockName;

        public UtauElement(string name)
        {
            BlockName = name;
        }

        public UtauElement(string name, Dictionary<string, string> attributes) : this(name)
        {
            foreach (KeyValuePair<string, string> attribute in attributes)
            {
                Values.Add(attribute.Key, attribute.Value);
            }
        }

        private IDictionary<string, string> mValues = new Dictionary<string, string>();

        public IDictionary<string, string> Values
        {
            get { return mValues; }
        }

        public void output(StringBuilder sb)
        {
            sb.AppendLine(BlockName);
            foreach (KeyValuePair<string, string> v in Values)
            {
                sb.AppendLine(v.Key + "=" + v.Value);
            }
        }

        public void Clear()
        {
            //明示的に空白を送らないと消してくれないので
            string[] keys = new string[Values.Keys.Count];
            Values.Keys.CopyTo(keys, 0);
            foreach (string key in keys)
            {
                this[key] = "";
            }
            this["Piches"] = "";
            this["PBS"] = "";
            this["PBW"] = "";
            this["PBY"] = "";
            this["VBR"] = "";
        }

        /// <summary>
        /// プロパティを直接指定して取得する。
        /// 専用プロパティがない場合、または値の自動変換が好ましくない場合に使用。
        /// </summary>
        /// <param name="index">プロパティ名</param>
        /// <returns></returns>
        public string this[string index]
        {
            get
            {
                if (Values.ContainsKey(index))
                {
                    return Values[index];
                }
                return "";
            }
            set
            {
                if (Values.ContainsKey(index))
                {
                    Values[index] = value;
                }
                else
                {
                    Values.Add(index, value);
                }
            }
        }

        /// <summary>
        /// 選択状態のオブジェクトかどうかを返す。
        /// UTAU仕様では範囲外のオブジェクトも取得できるが、
        /// そこに影響を与えたくない場合に使う。
        /// </summary>
        /// <returns></returns>
        public bool IsSelected()
        {
            return (BlockName != "[#PREV]" && BlockName != "[#NEXT]");
        }

        /// <summary>
        /// この要素が休符かどうかを返す
        /// </summary>
        /// <returns></returns>
        public bool IsRestNote()
        {
            return this["Lyric"] == "R";
        }

        /// <summary>
        /// 指定した言葉が含まれているかどうかを返す（完全一致）
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public bool IsLyricIn(string[] words)
        {
            string lyric = Lyric;
            foreach (string v in words)
            {
                if (lyric == v) return true;
            }
            return false;
        }

        /// <summary>
        /// 歌詞
        /// </summary>
        public string Lyric
        {
            get { return this["Lyric"]; }
            set { this["Lyric"] = value; }
        }

        /// <summary>
        /// 音階を示すNoteオブジェクト
        /// </summary>
        public Note Note
        {
            get { return Note.ByNoteNumber(NoteNum); }
            set { NoteNum = value.NoteNumber; }
        }

        /// <summary>
        /// 音階を示す数値
        /// </summary>
        public int NoteNum
        {
            get { return ParseInt(this["NoteNum"], 0); }
            set { this["NoteNum"] = value.ToString(); }
        }

        /// <summary>
        /// 音長を示す数値
        /// </summary>
        public int Length
        {
            get { return ParseInt(this["Length"], 0); }
            set { this["Length"] = value.ToString(); }
        }

        public FlagList GetFlagsList()
        {
            return new FlagParser().Parse(this["Flags"]);
        }

        public void SetFlagsList(FlagList val)
        {
            this["Flags"] = val.ToAttribute();
        }

        public int Moduration
        {
            get { return Math.Min(Math.Max(-200, ParseInt(this["Moduration"], 100)), 200); }
            set { this["Moduration"] = value.ToString(); }
        }

        /// <summary>
        /// ボリュームのパーセント値
        /// </summary>
        public int Intensity
        {
            get
            {
                //0～200
                //デフォルトは100
                return Math.Min(Math.Max(0, ParseInt(this["Intensity"], 100)), 200);
            }
            set { this["Intensity"] = value.ToString(); }
        }

        private int ParseInt(string val, int def)
        {
            int res;
            if (!int.TryParse(val, out res))
            {
                res = def;
            }
            return res;
        }

        public PitchBendList PitchList
        {
            get
            {
                return new PitchBendList(this["PBS"], this["PBW"], this["PBY"]);
            }
            set
            {
                this["PBS"] = value.GetPBS();
                this["PBW"] = value.GetPBW();
                this["PBY"] = value.GetPBY();
            }
        }
    }
}