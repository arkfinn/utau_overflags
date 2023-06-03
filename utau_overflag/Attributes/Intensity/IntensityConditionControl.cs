using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Conditions;
using Utau.OverFlags.Domain.Attributes.Intensity;
using Utau.OverFlags.Domain.Attributes;

namespace utau_overflags.Attributes.Intensity
{
    public partial class IntensityConditionControl :ConditionControl
    {
        private readonly ComparerPreparation comparation = new ComparerPreparation();
     
        public IntensityConditionControl()
        {
            InitializeComponent();
            InitializeComboBox(comboComparer, comparation.CreateParser());
        }
        
        public IntensityConditionControl(IntensityCondition condition):this()
        {
            Import(condition);
        }

        private void formChanged(object sender, EventArgs e)
        {
            NotifyChanged();
        }

        public override CondBase Export()
        {
            return new IntensityCondition(comparation.CreateComparer(comboComparer, FetchIntensityValue()));
        }

        private int FetchIntensityValue()
        {
            return Decimal.ToInt32(numIntensity.Value);
        }

        public void Import(IntensityCondition cond)
        {
            numIntensity.Value = cond.Comparer.Value;
            comboComparer.SelectedItem = cond.Comparer.Method;
            AnnualChanged();
        }

        public override void Import(CondBase cond)
        {
            if (cond.GetType() != typeof(IntensityCondition))
                throw new ArgumentException();

            Import((IntensityCondition)cond);
        }
    }
}
