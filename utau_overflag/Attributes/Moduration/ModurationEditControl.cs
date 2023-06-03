using System;
using Utau.OverFlags.Domain.Attributes;
using Utau.OverFlags.Domain.Attributes.Moduration;
using utau_overflags.Edits;

namespace utau_overflags.Attributes.Moduration
{
    public partial class ModurationEditControl : EditControl
    {
        private CalculatorPreparation calculation = new CalculatorPreparation();

        public ModurationEditControl()
        {
            InitializeComponent();
            InitializeComboBox(comboCalculator, calculation.CreateParser());
        }

        public ModurationEditControl(ModurationEdit edit)
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
            return Decimal.ToInt32(numModuration.Value);
        }

        public override EditBase Export()
        {
            return new ModurationEdit(calculation.CreateCalculator(CalculatorText(), CalculateValue()));
        }

        public override void Import(EditBase edit)
        {
            if (edit.GetType() != typeof(ModurationEdit))
                throw new ArgumentException();

            Import((ModurationEdit)edit);
        }

        public void Import(ModurationEdit edit)
        {
            numModuration.Value = edit.Calculator.Value;
            comboCalculator.SelectedItem = edit.Calculator.Method;
            AnnualChanged();
        }
    }
}