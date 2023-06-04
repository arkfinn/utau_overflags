using System.Collections.Generic;
using System.Xml.Serialization;
using Utau.Elements;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Flags;
using Utau.OverFlags.Domain.Attributes.Intensity;
using Utau.OverFlags.Domain.Attributes.Length;
using Utau.OverFlags.Domain.Attributes.Lyric;
using Utau.OverFlags.Domain.Attributes.Moduration;
using Utau.OverFlags.Domain.Attributes.Note;
using Utau.OverFlags.Domain.Attributes.Others;
using Utau.OverFlags.Domain.Attributes.Vibrato;

namespace Utau.OverFlags.Domain.Contracts
{
    public class Contract
    {
        static public Contract Empty()
        {
            return new Contract(new List<CondBase>(), new List<EditBase>());
        }

        private Contract()
        {
        }

        [XmlElement(typeof(CondBase))]
        [XmlElement(typeof(LyricCondition))]
        [XmlElement(typeof(IntensityCondition))]
        [XmlElement(typeof(NoteCondition))]
        [XmlElement(typeof(LengthCondition))]
        public List<CondBase> Conditions;

        [XmlElement(typeof(EditBase))]
        [XmlElement(typeof(LengthEdit))]
        [XmlElement(typeof(LyricEdit))]
        [XmlElement(typeof(IntensityEdit))]
        [XmlElement(typeof(ModurationEdit))]
        [XmlElement(typeof(VbrEdit))]
        [XmlElement(typeof(FlagsEdit))]
        [XmlElement(typeof(OthersEdit))]
        [XmlElement(typeof(NoteEdit))]
        public List<EditBase> Edits;

        public Contract(List<CondBase> conditions, List<EditBase> edits)
        {
            Conditions = conditions;
            Edits = edits;
        }

        private string getConditionDescription()
        {
            List<string> cond_texts = new List<string>();
            foreach (CondBase cond in Conditions)
            {
                if (cond.Enabled) cond_texts.Add(cond.ToString());
            }
            if (cond_texts.Count <= 0)
            {
                return "無条件で、";
            }
            return string.Join("、", cond_texts.ToArray()) + "の時、";
        }

        private string getEditDescription()
        {
            List<string> edit_texts = new List<string>();
            foreach (EditBase edit in Edits)
            {
                if (edit.Enabled) edit_texts.Add(edit.ToString());
            }
            if (edit_texts.Count <= 0)
            {
                return "何もしない";
            }
            return string.Join("、", edit_texts.ToArray()) + "する";
        }

        public override string ToString()
        {
            return getConditionDescription() + getEditDescription();
        }

        public bool IsSatisfied(UtauElement elm)
        {
            foreach (CondBase cond in Conditions)
            {
                if (!cond.IsApply(elm)) return false;
            }
            return true;
        }

        public bool Satisfy(UtauElement elm)
        {
            if (!IsSatisfied(elm)) return false;

            bool res = false;
            foreach (EditBase edit in Edits)
            {
                if (edit.Edit(elm)) res = true;
            }
            return res;
        }
    }
}