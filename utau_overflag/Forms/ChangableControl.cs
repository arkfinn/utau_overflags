using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Utau.OverFlags.Domain.Choices;

namespace utau_overflags.Attributes
{
    public class ChangableControl : UserControl
    {
        private bool changed = false;
        public bool IsChanged
        {
            get { return changed; }
        }

        protected void NotifyChanged()
        {
            changed = true;
        }

        protected void AnnualChanged()
        {
            changed = false;
        }

        protected void InitializeComboBox(ComboBox combo, IChoicable wordset)
        {
            combo.BeginUpdate();
            foreach (string word in wordset.Choices)
            {
                combo.Items.Add(word);
            }
            combo.EndUpdate();
            AnnualChanged();
        }

    }
}
