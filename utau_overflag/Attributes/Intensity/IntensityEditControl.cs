using System;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Intensity
{
    public partial class IntensityEditControl : EditControl
    {
        private CalculatorPreparation calculation = new CalculatorPreparation();

        public IntensityEditControl()
        {
            InitializeComponent();
            InitializeComboBox(comboCalculator, calculation.CreateParser());
        }

        public IntensityEditControl(IntensityEdit edit)
            : this()
        {
            Import(edit);
        }

        private void formChanged(object sender, EventArgs e)
        {
            NotifyChanged();
        }

        private string CalculatorText()
        {
            return (string)comboCalculator.SelectedItem;
        }

        private int CalculateValue()
        {
            return Decimal.ToInt32(numIntensity.Value);
        }

        public override EditBase Export()
        {
            return new IntensityEdit(calculation.CreateCalculator(CalculatorText(), CalculateValue()));
        }

        public override void Import(EditBase edit)
        {
            if (edit.GetType() != typeof(IntensityEdit))
                throw new ArgumentException();

            Import((IntensityEdit)edit);
        }

        public void Import(IntensityEdit intensityEdit)
        {
            numIntensity.Value = intensityEdit.Calculator.Value;
            comboCalculator.SelectedItem = intensityEdit.Calculator.Method;
            AnnualChanged();
        }
    }
}