﻿using Utau.Elements;

namespace Utau.OverFlags.Domain.Attributes
{
    abstract public class EditBase
    {
        private bool _Enabled = true;

        public bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }

        public bool Edit(UtauElement elm)
        {
            if (Enabled)
            {
                return RunEdit(elm);
            }
            return false;
        }

        abstract protected bool RunEdit(UtauElement elm);
    }
}