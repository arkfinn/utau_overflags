using NUnit.Framework;
using System.Collections.Generic;
using Utau.OverFlags.Domain.CalculateCommands;
using utau_overflags.Attributes.Comparers;
using utau_overflags.Attributes.Flags;
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

namespace utau_overflags
{
    internal class ContractListTest
    {
        [Test]
        public void 新Styleの出力確認()
        {
            List<Contract> list = new List<Contract>();
            list.Add(new Contract(LyricConditions(), LyricEdits()));
            list.Add(new Contract(IntensityConditions(), IntensityEdits()));
            list.Add(new Contract(NoteConditions(), ModurationEdits()));
            list.Add(new Contract(LengthConditions(), VbrEdits()));
            list.Add(new Contract(new List<CondBase>(), FlagsEdits()));
            ContractList c = new ContractList(list);
            // c.Output("contract_list");
        }

        private static List<EditBase> LyricEdits()
        {
            List<EditBase> edits = new List<EditBase>();
            edits.Add(new LyricEdit(new ReplaceConnector("か")));
            edits.Add(new LyricEdit(new PrefixConnector("き")));
            edits.Add(new LyricEdit(new SuffixConnector("く")));
            return edits;
        }

        private List<CondBase> LyricConditions()
        {
            List<CondBase> conditions = new List<CondBase>();
            conditions.Add(new LyricCondition(new ExactMatching("あ")));
            conditions.Add(new LyricCondition(new PartialMatching("い")));
            conditions.Add(new LyricCondition(new ForwardMatching("う")));
            conditions.Add(new LyricCondition(new BackwardMatching("え")));
            return conditions;
        }

        private static List<EditBase> IntensityEdits()
        {
            List<EditBase> edits = new List<EditBase>();
            edits.Add(new IntensityEdit(new AdditionCommand(1)));
            edits.Add(new IntensityEdit(new AssignmentCommand(2)));
            edits.Add(new IntensityEdit(new PercentCommand(3)));
            edits.Add(new IntensityEdit(new SubtractionCommand(4)));
            return edits;
        }

        private List<CondBase> IntensityConditions()
        {
            List<CondBase> conditions = new List<CondBase>();
            conditions.Add(new IntensityCondition(new EqualsComparer(11)));
            conditions.Add(new IntensityCondition(new LessThanEqualsComparer(12)));
            conditions.Add(new IntensityCondition(new MoreThanEqualsComparer(13)));
            return conditions;
        }

        private List<CondBase> NoteConditions()
        {
            List<CondBase> conditions = new List<CondBase>();
            conditions.Add(new NoteCondition(new EqualsComparer(21)));
            conditions.Add(new NoteCondition(new LessThanEqualsComparer(22)));
            conditions.Add(new NoteCondition(new MoreThanEqualsComparer(23)));
            return conditions;
        }

        private static List<EditBase> ModurationEdits()
        {
            List<EditBase> edits = new List<EditBase>();
            edits.Add(new ModurationEdit(new AdditionCommand(31)));
            edits.Add(new ModurationEdit(new AssignmentCommand(32)));
            edits.Add(new ModurationEdit(new PercentCommand(33)));
            edits.Add(new ModurationEdit(new SubtractionCommand(34)));
            return edits;
        }

        private List<CondBase> LengthConditions()
        {
            List<CondBase> conditions = new List<CondBase>();
            conditions.Add(new LengthCondition(new EqualsComparer(21)));
            conditions.Add(new LengthCondition(new LessThanEqualsComparer(22)));
            conditions.Add(new LengthCondition(new MoreThanEqualsComparer(23)));
            return conditions;
        }

        private static List<EditBase> VbrEdits()
        {
            List<EditBase> edits = new List<EditBase>();
            edits.Add(new VbrEdit("あ"));
            return edits;
        }

        private static List<EditBase> FlagsEdits()
        {
            List<EditBase> edits = new List<EditBase>();
            edits.Add(new FlagsEdit(new utau_overflags.Attributes.Flags.EditTypes.FlagsAddition("Y1")));
            edits.Add(new FlagsEdit(new utau_overflags.Attributes.Flags.EditTypes.FlagsCalculator("Y2")));
            edits.Add(new FlagsEdit(new utau_overflags.Attributes.Flags.EditTypes.FlagsOverWriter("Y3")));
            edits.Add(new FlagsEdit(new utau_overflags.Attributes.Flags.EditTypes.FlagsReplacer("Y4")));
            return edits;
        }

        /*
         * Flags
         * Vibrato
         */

        [Test]
        public void ContractListの読み込み()
        {
            ContractList list = ConditionList.FromFileNewStyle("TestFiles/contract_list.xml");
            Assert.That(list, Is.Not.Null);
            Assert.That(list.Items.Count, Is.EqualTo(5));
            Assert.That(list.Items[0].ToString(), Is.EqualTo("「あ」と完全一致、「い」と部分一致、「う」と前方一致、「え」と後方一致の時、歌詞に「か」をセット、歌詞に「き」を前に追加、歌詞に「く」を後に追加する"));
            Assert.That(list.Items[1].ToString(), Is.EqualTo("音量が11と同値、音量が12以下、音量が13以上の時、音量を1加算、音量を2に設定、音量を3%に変更、音量を4減算する"));
            Assert.That(list.Items[2].ToString(), Is.EqualTo("A0と同値、A#0以下、B0以上の時、モジュレーションを31加算、モジュレーションを32に設定、モジュレーションを33%に変更、モジュレーションを34減算する"));
            Assert.That(list.Items[3].ToString(), Is.EqualTo("音長が21と同値、音長が22以下、音長が23以上の時、VBRに「あ」を設定する"));
            Assert.That(list.Items[4].ToString(), Is.EqualTo("無条件で、Flags「Y1」を追加、Flags「Y2」で計算、Flags「Y3」で上書き、Flags「Y4」で置換する"));
        }

        [Test]
        public void 旧ファイルの読み込み()
        {
            ContractList list = ContractList.FromFile("TestFiles/ろにテト！.xml");
            Assert.That(list.Items.Count, Is.EqualTo(7));
            Assert.That(list[0].ToString(), Is.EqualTo("G5以上の時、Flags「Y0g-15H20L4」で上書きする"));
            Assert.That(list[1].ToString(), Is.EqualTo("D#5以上の時、Flags「Y0g-10H20L4」で上書きする"));
            Assert.That(list[2].ToString(), Is.EqualTo("C#5以上の時、Flags「Y0g-8H15L2」で上書きする"));
            Assert.That(list[3].ToString(), Is.EqualTo("D#4以上の時、Flags「g-3」を追加する"));
            Assert.That(list[4].ToString(), Is.EqualTo("C4以上の時、Flags「」を追加する"));
            Assert.That(list[5].ToString(), Is.EqualTo("G3以下の時、Flags「Y0g8」で上書きする"));
            Assert.That(list[6].ToString(), Is.EqualTo("A3以下の時、Flags「Y0g5」で上書きする"));
        }
    }
}