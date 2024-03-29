﻿using System.Xml.Serialization;
using Utau.Elements;
using Utau.OverFlags.Domain.Commands.Comparers;

namespace Utau.OverFlags.Domain.Attributes.Note
{
    public class NoteCondition : CondBase
    {
        public NoteCondition() : this(new LessThanEqualsComparer(60))
        {
        }

        public NoteCondition(Comparer comparer)
        {
            Comparer = comparer;
        }

        [XmlElement(typeof(Comparer))]
        [XmlElement(typeof(EqualsComparer))]
        [XmlElement(typeof(LessThanEqualsComparer))]
        [XmlElement(typeof(MoreThanEqualsComparer))]
        public Comparer Comparer;

        protected override bool DecideApply(UtauElement elm)
        {
            return Comparer.Evaluate(elm.NoteNum);
        }

        override public string ToString()
        {
            return Utau.Domain.Notes.Note.ByNoteNumber(Comparer.Value).ToString() + Comparer.Method;
        }
    }
}