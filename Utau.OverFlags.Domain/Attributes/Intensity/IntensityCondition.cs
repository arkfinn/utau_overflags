﻿using System.Xml.Serialization;
using Utau.Elements;
using Utau.OverFlags.Domain.Commands.Comparers;

namespace Utau.OverFlags.Domain.Attributes.Intensity
{
    public class IntensityCondition : CondBase
    {
        public IntensityCondition() : this(new EqualsComparer(0))
        {
        }

        public IntensityCondition(Comparer comparer)
        {
            Comparer = comparer;
        }

        [XmlElement(typeof(Comparer))]
        [XmlElement(typeof(EqualsComparer))]
        [XmlElement(typeof(LessThanEqualsComparer))]
        [XmlElement(typeof(MoreThanEqualsComparer))]
        public Comparer Comparer;

        override protected bool DecideApply(UtauElement elm)
        {
            return Comparer.Evaluate(elm.Intensity);
        }

        override public string ToString()
        {
            return "音量が" + Comparer.ToString();
        }
    }
}