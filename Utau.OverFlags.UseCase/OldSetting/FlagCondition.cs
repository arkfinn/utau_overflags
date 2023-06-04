using System.Collections.Generic;
using Utau.Elements;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Flags;
using Utau.OverFlags.Domain.Attributes.Intensity;
using Utau.OverFlags.Domain.Attributes.Length;
using Utau.OverFlags.Domain.Attributes.Lyric;
using Utau.OverFlags.Domain.Attributes.Moduration;
using Utau.OverFlags.Domain.Attributes.Note;
using Utau.OverFlags.Domain.Attributes.Vibrato;
using Utau.OverFlags.Domain.Commands.Comparers;
using Utau.OverFlags.Domain.Contracts;

namespace Utau.OverFlags.Application.OldSetting
{
    public enum WriteType
    {
        Add,
        OverWrite,
        Replace,
        Math,
    }

    public enum Operator
    {
        More,
        Equal,
        Less
    }

    public enum ConnectType
    {
        Set,
        Prefix,
        Suffix,
    }

    public class FlagCondition
    {
        public const int FirstVersion = 0;
        public const int Version1500 = 1500;

        public const int NowVersion = Version1500;

        private int _Version = NowVersion;

        public int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        static public FlagCondition CreateEmpty()
        {
            FlagCondition f = new FlagCondition();
            f.NoteCond = new NoteCondition(new MoreThanEqualsComparer(24));
            f.Version = NowVersion;
            return f;
        }

        public FlagCondition()
        {
        }

        private Contract ToContract()
        {
            List<CondBase> conditions = new List<CondBase>();
            conditions.Add(NoteCond);
            conditions.Add(WordCond);
            conditions.Add(IntensityCond);
            conditions.Add(lengthCond);

            List<EditBase> edits = new List<EditBase>();
            edits.Add(flagsEdit);
            edits.Add(VbrEdit);
            edits.Add(IntensityEdit);
            edits.Add(WordEdit);
            edits.Add(ModurationEdit);
            return new Contract(conditions, edits);
        }

        #region 条件_ノート

        public NoteCondition NoteCond = new NoteCondition();

        public bool UseNoteCond
        {
            get { return NoteCond.Enabled; }
            set { NoteCond.Enabled = value; }
        }

        #endregion 条件_ノート

        #region 条件_歌詞

        public LyricCondition WordCond = new LyricCondition();

        public bool UseWordCond
        {
            get { return WordCond.Enabled; }
            set { WordCond.Enabled = value; }
        }

        #endregion 条件_歌詞

        #region 条件_音量

        public IntensityCondition IntensityCond = new IntensityCondition();

        public bool UseIntensityCond
        {
            get { return IntensityCond.Enabled; }
            set { IntensityCond.Enabled = value; }
        }

        #endregion 条件_音量

        #region 条件_length

        public LengthCondition lengthCond = new LengthCondition();

        public bool UseLengthCond
        {
            get { return lengthCond.Enabled; }
            set { lengthCond.Enabled = value; }
        }

        #endregion 条件_length

        #region 操作_Flags

        public FlagsEdit flagsEdit = new FlagsEdit();

        public bool UseFlagsEdit
        {
            get { return flagsEdit.Enabled; }
            set { flagsEdit.Enabled = value; }
        }

        #endregion 操作_Flags

        #region 操作_vbr

        public VbrEdit VbrEdit = new VbrEdit();

        public bool UseVbrEdit
        {
            get { return VbrEdit.Enabled; }
            set { VbrEdit.Enabled = value; }
        }

        #endregion 操作_vbr

        #region 操作_Intensity

        public IntensityEdit IntensityEdit = new IntensityEdit();

        public bool UseIntensityEdit
        {
            get { return IntensityEdit.Enabled; }
            set { IntensityEdit.Enabled = value; }
        }

        #endregion 操作_Intensity

        #region 操作_Word

        public LyricEdit WordEdit = new LyricEdit();

        public bool UseWordEdit
        {
            get { return WordEdit.Enabled; }
            set { WordEdit.Enabled = value; }
        }

        #endregion 操作_Word

        #region 操作_Moduration

        public ModurationEdit ModurationEdit = new ModurationEdit();

        public bool UseModurationEdit
        {
            get { return ModurationEdit.Enabled; }
            set { ModurationEdit.Enabled = value; }
        }

        #endregion 操作_Moduration

        public override string ToString()
        {
            if (Version < Version1500)
            {
                NoteCond.Enabled = true;
                flagsEdit.Enabled = true;
            }
            return ToContract().ToString();
        }

        /// <summary>
        /// 指定エレメントが条件を満たしているかどうかを返す
        /// </summary>
        /// <param name="elm"></param>
        /// <returns></returns>
        public bool IsApply(UtauElement elm)
        {
            if (Version < Version1500)
            {
                NoteCond.Enabled = true;
            }
            return ToContract().IsSatisfied(elm);
        }

        public bool ApplyCondition(UtauElement elm)
        {
            if (Version < Version1500)
            {
                flagsEdit.Enabled = true;
            }
            return ToContract().Satisfy(elm);
        }
    }
}