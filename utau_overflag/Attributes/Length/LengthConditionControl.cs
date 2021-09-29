using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Attributes.Comparers;
using utau_overflags.Conditions;

namespace utau_overflags.Attributes.Length
{
    public partial class LengthConditionControl : ConditionControl
    {
        private readonly ComparerPreparation comparation = new ComparerPreparation();
        public LengthConditionControl()
        {
            InitializeComponent();
            InitializeComboBox(comboComparer, comparation.CreateParser());
        }
        public LengthConditionControl(LengthCondition condition)
            : this()
        {
            Import(condition);
        }

        private void formChanged(object sender, EventArgs e)
        {
            NotifyChanged();
        }

        public override CondBase Export()
        {
            return new LengthCondition(comparation.CreateComparer(comboComparer, FetchLengthValue()));
        }

        private int FetchLengthValue()
        {
            return Decimal.ToInt32(numLength.Value);
        }

        public void Import(LengthCondition cond)
        {
            numLength.Value = cond.Comparer.Value;
            comboComparer.SelectedItem = cond.Comparer.Method;
            AnnualChanged();
        }

        public override void Import(CondBase cond)
        {
            if (cond.GetType() != typeof(LengthCondition))
                throw new ArgumentException();

            Import((LengthCondition)cond);
        }
    }
}
