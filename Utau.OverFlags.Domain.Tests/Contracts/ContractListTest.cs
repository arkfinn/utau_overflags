using NUnit.Framework;
using System.Collections.Generic;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Flags;
using Utau.OverFlags.Domain.Attributes.Intensity;
using Utau.OverFlags.Domain.Attributes.Length;
using Utau.OverFlags.Domain.Attributes.Lyric;
using Utau.OverFlags.Domain.Attributes.Moduration;
using Utau.OverFlags.Domain.Attributes.Note;
using Utau.OverFlags.Domain.Attributes.Vibrato;
using Utau.OverFlags.Domain.Commands.Calculations;
using Utau.OverFlags.Domain.Commands.Comparers;
using Utau.OverFlags.Domain.Commands.Connectors;
using Utau.OverFlags.Domain.Commands.Flags;
using Utau.OverFlags.Domain.Commands.WordLikes;

namespace Utau.OverFlags.Domain.Contracts
{
    class ContractListTest
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
            edits.Add(new FlagsEdit(new FlagsAddition("Y1")));
            edits.Add(new FlagsEdit(new FlagsCalculator("Y2")));
            edits.Add(new FlagsEdit(new FlagsOverWriter("Y3")));
            edits.Add(new FlagsEdit(new FlagsReplacer("Y4")));
            return edits;
        }

        /*
         * Flags
         * Vibrato
         */

    }
}
