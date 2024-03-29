﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Utau.OverFlags.Domain.Commands.Comparers
{
    public abstract class Comparer
    {
        protected Comparer() { }
        public Comparer(int value)
        {
            Value = value;
        }
        public int Value;

        public abstract string Method { get; }
        public abstract bool Evaluate(int target);

        public override string ToString()
        {
            return Value + Method;
        }
    }
}
