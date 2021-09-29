using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace utau_overflags.Forms
{
    public partial class EditDialogPanel : UserControl
    {
        public EditDialogPanel()
        {
            InitializeComponent();
        }

        public void AddContents(Control control)
        {
            groupBox1.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }
    }
}
