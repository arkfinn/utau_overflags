﻿using System.Xml.Serialization;
using Utau.Elements;
using utau_overflags.Attributes.Comparers;
using utau_overflags.Conditions;

namespace utau_overflags.Attributes.Length
{
    public class LengthCondition : CondBase
    {
        public LengthCondition() : this(new EqualsComparer(0))
        {
        }

        public LengthCondition(Comparer comparer)
        {
            this.Comparer = comparer;
        }

        [XmlElement(typeof(Comparer))]
        [XmlElement(typeof(EqualsComparer))]
        [XmlElement(typeof(LessThanEqualsComparer))]
        [XmlElement(typeof(MoreThanEqualsComparer))]
        public Comparer Comparer;

        override protected bool DecideApply(UtauElement elm)
        {
            return Comparer.Evaluate(elm.Length);
        }

        override public string ToString()
        {
            return "音長が" + Comparer.ToString();
        }

        public override ConditionControl CreateControl()
        {
            return new LengthConditionControl(this);
        }
    }
}