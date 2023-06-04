using System;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Length;
using utau_overflags.DataEntry.Attributes;

namespace utau_overflags.Attributes.Length
{
    public partial class LengthEditControl : EditControl
    {
        private CalculatorPreparation calculation = new CalculatorPreparation();

        public LengthEditControl()
        {
            InitializeComponent();
            InitializeComboBox(comboCalculator, calculation.CreateParser());
        }

        public LengthEditControl(LengthEdit edit)
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
            return Decimal.ToInt32(numLength.Value);
        }

        public override EditBase Export()
        {
            return new LengthEdit(calculation.CreateCalculator(CalculatorText(), CalculateValue()));
        }

        public override void Import(EditBase edit)
        {
            if (edit.GetType() != typeof(LengthEdit))
                throw new ArgumentException();

            Import((LengthEdit)edit);
        }

        public void Import(LengthEdit edit)
        {
            numLength.Value = edit.Calculator.Value;
            comboCalculator.SelectedItem = edit.Calculator.Method;
            AnnualChanged();
        }
    }
}