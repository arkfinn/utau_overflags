using System;
using System.Collections.Generic;

namespace Utau.Domain.PitchBends
{
    public class PitchBendList
    {
        // ピッチベンド周りの処理はoverflagsでの利用がないため実装していない。

        public PitchBendList(string pbs, string pbw, string pby)
        {
            SetPBS(pbs);
        }

        private int StartPos = 0;
        private int StartY = 0;

        public void SetPBS(string pbs)
        {
            StartPos = 0;
            StartY = 0;
            string[] prms = pbs.Split(';');
            if (0 < prms.Length)
            {
                if (!int.TryParse(prms[0], out StartPos))
                {
                    StartPos = 0;
                }

                if (1 < prms.Length)
                {
                    if (!int.TryParse(prms[1], out StartY))
                    {
                        StartY = 0;
                    }
                }
            }
        }

        public string GetPBS()
        {
            return StartPos.ToString() + ";" + StartY.ToString();
        }

        public string GetPBW()
        {
            List<string> res = new List<string>();
            foreach (UtauPitchBendElement v in Elements)
            {
                res.Add(v.Width.ToString());
            }
            return String.Join(",", res.ToArray());
        }

        public string GetPBY()
        {
            List<string> res = new List<string>();
            foreach (UtauPitchBendElement v in Elements)
            {
                res.Add(v.Y.ToString());
            }
            return String.Join(",", res.ToArray());
        }

        private void SetElements(string pbw, string pby)
        {
            Elements.Clear();
            string[] ws = pbw.Split(',');
            string[] ys = pby.Split(',');
            for (int i = 0; i < ws.Length; i++)
            {
                UtauPitchBendElement elm = new UtauPitchBendElement();
                elm.SetWidth(ws[i]);
                elm.SetY((i < ys.Length) ? ys[i] : "");
            }
        }

        private IList<UtauPitchBendElement> mElements;

        public IList<UtauPitchBendElement> Elements
        {
            get
            {
                if (mElements == null)
                {
                    mElements = new List<UtauPitchBendElement>();
                }
                return mElements;
            }
        }
    }

    public class UtauPitchBendElement
    {
        public int Width = 0;

        public void SetWidth(string val)
        {
            Width = ParseInt(val);
        }

        public int Y = 0;

        public void SetY(string val)
        {
            Y = ParseInt(val);
        }

        private int ParseInt(string val)
        {
            int res;
            if (!int.TryParse(val, out res))
            {
                res = 0;
            }
            return res;
        }
    }
}