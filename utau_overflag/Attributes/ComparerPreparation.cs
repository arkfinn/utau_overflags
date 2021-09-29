using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Attributes.Comparers;

namespace utau_overflags.Attributes
{
    class ComparerPreparation
    {
        public ComparerParser CreateParser()
        {
            return new ComparerParser();
        }

        public Comparer CreateComparer(ComboBox combo, int value)
        {
            return CreateParser().Parse((string)combo.SelectedItem, value);
        }        
    }
}
