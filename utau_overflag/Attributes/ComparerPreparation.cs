using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utau.OverFlags.Domain.Commands.Comparers;

namespace utau_overflags.Attributes
{
    class ComparerPreparation
    {
        public ComparerChoice CreateParser()
        {
            return new ComparerChoice();
        }

        public Comparer CreateComparer(ComboBox combo, int value)
        {
            return CreateParser().Parse((string)combo.SelectedItem, value);
        }        
    }
}
