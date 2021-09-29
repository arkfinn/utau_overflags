using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace utau_overflagstest.Attributes
{
    class ControlTestBase
    {
        protected Form CreateForm(Control control)
        {
            Form form = new Form();
            form.Controls.Add(control);
            form.Visible = true;
            return form;
        }
    }
}
