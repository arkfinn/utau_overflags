using System;
using System.Collections.Generic;
using System.Xml;
using Utau.OverFlags.Domain.CalculateCommands;
using utau_overflags.Attributes.Comparers;
using utau_overflags.Attributes.Flags;
using utau_overflags.Attributes.Flags.EditTypes;
using utau_overflags.Attributes.Intensity;
using utau_overflags.Attributes.Length;
using utau_overflags.Attributes.Lyric;
using utau_overflags.Attributes.Lyric.Connectors;
using utau_overflags.Attributes.Lyric.WordLikes;
using utau_overflags.Attributes.Moduration;
using utau_overflags.Attributes.Note;
using utau_overflags.Attributes.Vibrato;
using utau_overflags.Conditions;
using utau_overflags.Edits;
using UtauPluginSet.Attributes.Calculators;

namespace utau_overflags.OldSetting
{
    public class OldFlagCondition
    {
        public const int FirstVersion = 0;
        public const int Version1500 = 1500;

        public const int NowVersion = Version1500;

        private int _Version = 0;

        public int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        #region 条件_ノート_未

        public bool UseNoteCond;
        public int TargetNote;
        public string Operator;

        public NoteCondition CreateNoteCondition()
        {
            NoteCondition cond = new NoteCondition(CreateComparer(Operator, TargetNote));
            cond.Enabled = UseNoteCond;
            return cond;
        }

        #endregion 条件_ノート_未

        #region 条件_歌詞

        public bool UseWordCond = false;
        public string TargetWord = "";
        public string TargetWordLike = "";

        private LyricCondition CreateWordCondition()
        {
            LyricCondition cond = new LyricCondition(createMatching(TargetWordLike, TargetWord));
            cond.Enabled = UseWordCond;
            return cond;
        }

        private Matching createMatching(string method, string value)
        {
            if (method == "")
                return new ExactMatching(value);

            MatchingParser parser = new MatchingParser();
            return parser.Parse(method, value);
        }

        #endregion 条件_歌詞

        #region 条件_音量

        private IntensityCondition IntensityCond = new IntensityCondition();

        public bool UseIntensityCond;
        public int TargetIntensity;
        public string TargetIntensityOp;

        public IntensityCondition CreateIntensityCondition()
        {
            IntensityCondition cond = new IntensityCondition(CreateComparer(TargetIntensityOp, TargetIntensity));
            cond.Enabled = UseIntensityCond;
            return cond;
        }

        private Comparer CreateComparer(string method, int value)
        {
            if (method == "")
                return new MoreThanEqualsComparer(value);

            ComparerParser parser = new ComparerParser();
            return parser.Parse(method, value);
        }

        #endregion 条件_音量

        #region 条件_length

        public bool UseLengthCond;
        public int LengthCond;

        public LengthCondition CreateLengthCondition()
        {
            LengthCondition cond = new LengthCondition(CreateComparer("More", LengthCond));
            cond.Enabled = UseLengthCond;
            return cond;
        }

        #endregion 条件_length

        #region 操作_Flags_未

        public bool UseFlagsEdit;
        public string WriteFlagsType;
        public string Flags;

        private FlagsEdit CreateFlagsEdit()
        {
            FlagsEdit cond = new FlagsEdit(CreateEditType(WriteFlagsType, Flags));
            cond.Enabled = UseFlagsEdit;
            return cond;
        }

        private EditType CreateEditType(string method, string value)
        {
            if (method == "")
                return new utau_overflags.Attributes.Flags.EditTypes.FlagsAddition(value);

            return new EditTypeParser().Parse(method, value);
        }

        #endregion 操作_Flags_未

        #region 操作_vbr

        public bool UseVbrEdit = false;
        public string Vbr = "";

        private VbrEdit CreateVbrEdit()
        {
            VbrEdit edit = new VbrEdit(Vbr);
            edit.Enabled = UseVbrEdit;
            return edit;
        }

        #endregion 操作_vbr

        #region 操作_Intensity

        private IntensityEdit IntensityEdit = new IntensityEdit();

        public bool UseIntensityEdit;
        public int Intensity;
        public string IntensityCalcType;

        public IntensityEdit CreateIntensityEdit()
        {
            IntensityEdit edit = new IntensityEdit(createCalculator(IntensityCalcType, Intensity));
            edit.Enabled = UseIntensityEdit;
            return edit;
        }

        private CalculateCommand createCalculator(string method, int value)
        {
            if (method == "")
                return new AssignmentCommand(value);

            CalculatorParser parser = new CalculatorParser();
            return parser.Parse(method, value);
        }

        #endregion 操作_Intensity

        #region 操作_Word

        public bool UseWordEdit = false;
        public string AddWord = "";
        public string WordConnectType = "";

        private LyricEdit CreateWordEdit()
        {
            LyricEdit cond = new LyricEdit(CreateConnector(WordConnectType, AddWord));
            cond.Enabled = UseWordCond;
            return cond;
        }

        private Connector CreateConnector(string method, string value)
        {
            if (method == "")
                return new ReplaceConnector(value);

            ConnectorParser parser = new ConnectorParser();
            return parser.Parse(method, value);
        }

        #endregion 操作_Word

        #region 操作_Moduration

        public bool UseModurationEdit;

        public int Moduration;

        public string ModurationCalcType;

        public ModurationEdit CreateModurationEdit()
        {
            ModurationEdit edit = new ModurationEdit(createCalculator(ModurationCalcType, Moduration));
            edit.Enabled = UseIntensityEdit;
            return edit;
        }

        #endregion 操作_Moduration

        public FlagCondition toFlagCondition()
        {
            SetupByVersion();
            FlagCondition cond = new FlagCondition();
            cond.NoteCond = CreateNoteCondition();
            cond.WordCond = CreateWordCondition();
            cond.IntensityCond = CreateIntensityCondition();
            cond.lengthCond = CreateLengthCondition();
            cond.flagsEdit = CreateFlagsEdit();
            cond.VbrEdit = CreateVbrEdit();
            cond.IntensityEdit = CreateIntensityEdit();
            cond.WordEdit = CreateWordEdit();
            cond.ModurationEdit = CreateModurationEdit();
            return cond;
        }

        private void SetupByVersion()
        {
            if (Version < Version1500)
            {
                UseNoteCond = true;
                UseFlagsEdit = true;
            }
        }

        internal static OldFlagCondition from(XmlNode nd)
        {
            OldFlagCondition cond = new OldFlagCondition();
            cond.setup(nd);
            return cond;
        }

        private void setup(XmlNode nd)
        {
            Version = fetchInt(nd, "Version");
            UseNoteCond = fetchBool(nd, "UseNoteCond");
            TargetNote = fetchInt(nd, "TargetNote");
            Operator = fetchString(nd, "Operator");
            UseWordCond = fetchBool(nd, "UseWordCond");
            TargetWord = fetchString(nd, "TargetWord");
            TargetWordLike = fetchString(nd, "TargetWordLike");
            UseIntensityCond = fetchBool(nd, "UseIntensityCond");
            TargetIntensity = fetchInt(nd, "TargetIntensity");
            TargetIntensityOp = fetchString(nd, "TargetIntensityOp");
            UseLengthCond = fetchBool(nd, "UseLengthCond");
            LengthCond = fetchInt(nd, "LengthCond");
            UseFlagsEdit = fetchBool(nd, "UseFlagsEdit");
            WriteFlagsType = fetchString(nd, "WriteType");
            Flags = fetchString(nd, "Flags");
            UseVbrEdit = fetchBool(nd, "UseVbrEdit");
            Vbr = fetchString(nd, "Vbr");
            UseIntensityEdit = fetchBool(nd, "UseIntensityEdit");
            Intensity = fetchInt(nd, "Intensity");
            IntensityCalcType = fetchString(nd, "IntensityCalcType");
            UseWordEdit = fetchBool(nd, "UseWordEdit");
            AddWord = fetchString(nd, "AddWord");
            WordConnectType = fetchString(nd, "WordConnectType");
            UseModurationEdit = fetchBool(nd, "UseModurationEdit");
            Moduration = fetchInt(nd, "Moduration");
            ModurationCalcType = fetchString(nd, "ModurationCalcType");
        }

        private bool fetchBool(XmlNode nd, string name)
        {
            XmlNode node = nd.SelectSingleNode(name);
            if (node == null) return false;
            return bool.Parse(node.InnerText); ;
        }

        private int fetchInt(XmlNode nd, string name)
        {
            XmlNode node = nd.SelectSingleNode(name);
            if (node == null) return 0;
            return int.Parse(node.InnerText); ;
        }

        private string fetchString(XmlNode nd, string name)
        {
            XmlNode node = nd.SelectSingleNode(name);
            if (node == null) return "";
            return node.InnerText;
        }

        private CalcType fetchCalcType(XmlNode nd, string name)
        {
            XmlNode node = nd.SelectSingleNode(name);
            if (node == null) return CalcType.Add;
            return (CalcType)Enum.Parse(typeof(CalcType), node.InnerText);
        }

        private WriteType fetchWriteType(XmlNode nd, string name)
        {
            XmlNode node = nd.SelectSingleNode(name);
            if (node == null) return WriteType.Replace;
            return (WriteType)Enum.Parse(typeof(WriteType), node.InnerText);
        }

        private ConnectType fetchConnectType(XmlNode nd, string name)
        {
            XmlNode node = nd.SelectSingleNode(name);
            if (node == null) return ConnectType.Set;
            return (ConnectType)Enum.Parse(typeof(ConnectType), node.InnerText);
        }

        internal Contract toContract()
        {
            SetupByVersion();
            return new Contract(CreateConditions(), CreateEdits());
        }

        private List<EditBase> CreateEdits()
        {
            List<EditBase> edits = new List<EditBase>();
            if (UseFlagsEdit) edits.Add(CreateFlagsEdit());
            if (UseVbrEdit) edits.Add(CreateVbrEdit());
            if (UseIntensityEdit) edits.Add(CreateIntensityEdit());
            if (UseWordEdit) edits.Add(CreateWordEdit());
            if (UseModurationEdit) edits.Add(CreateModurationEdit());
            return edits;
        }

        private List<CondBase> CreateConditions()
        {
            List<CondBase> conds = new List<CondBase>();
            if (UseNoteCond) conds.Add(CreateNoteCondition());
            if (UseWordCond) conds.Add(CreateWordCondition());
            if (UseIntensityCond) conds.Add(CreateIntensityCondition());
            if (UseLengthCond) conds.Add(CreateLengthCondition());
            return conds;
        }
    }
}