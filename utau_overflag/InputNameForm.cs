using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace utau_overflags
{
    public partial class InputNameForm : Form
    {
        public InputNameForm()
        {
            InitializeComponent();
        }

        private void RefleshPresetBox()
        {
            comboBox1.Items.Clear();
            var preset = new PresetController();
            foreach (FileInfo file in preset.FetchPresets())
            {
                comboBox1.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
        }

        private string _nowPreset = "";

        public string NowPreset
        {
            get { return _nowPreset; }
            set { _nowPreset = value; }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateErrorLabelVisible();
        }

        private void UpdateErrorLabelVisible()
        {
            string txt = GetFileName();
            if (0 < txt.Length)
            {
                button1.Enabled = true;
                var preset = new PresetController();
                label2.Visible = preset.Exists(txt);
            }
            else
            {
                label2.Visible = false;
                button1.Enabled = false;
            }
        }

        public string GetFileName()
        {
            string txt = "";
            if (radioButton1.Checked)
            {
                txt = comboBox1.Text;
            }
            else if (radioButton2.Checked)
            {
                txt = textBox1.Text;
            }
            return txt;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = radioButton1.Checked;
            textBox1.Enabled = radioButton2.Checked;
            UpdateErrorLabelVisible();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = radioButton1.Checked;
            textBox1.Enabled = radioButton2.Checked;
            UpdateErrorLabelVisible();
        }

        private void InputNameForm_Load(object sender, EventArgs e)
        {
            RefleshPresetBox();
            if (NowPreset != "")
            {
                radioButton1.Checked = true;
                comboBox1.SelectedItem = NowPreset;

            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateErrorLabelVisible();
        }
    }
}