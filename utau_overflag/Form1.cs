using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Utau.Domain.Scores;
using Utau.Elements;
using utau_overflags.Forms;

namespace utau_overflags
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool _IsChanged = false;

        public bool IsChanged
        {
            get { return _IsChanged; }
            set
            {
                _IsChanged = value;
                button5.Enabled = _IsChanged;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Binder = new Binder<ContractItem>(sortableListBox1);
            RefleshPresetBox();
            AddNewFlagCondition();
            IsChanged = false;
            Binder.SelectedIndex = -1;
        }

        private Binder<ContractItem> Binder;

        private ContractItem AddNewFlagCondition()
        {
            ContractItem f = new ContractItem(Contract.Empty());
            Binder.Add(f);
            IsChanged = true;
            return f;
        }

        private bool ShowSaveContractDialog()
        {
            if (!contractSetter1.Changed) return true;

            DialogResult res = MessageBox.Show(
                "条件の入力内容が変更されています。保存しますか？", "確認",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
            );
            switch (res)
            {
                case DialogResult.Cancel:
                    Binder.SelectedItem = NowSelectedItem;
                    return false;

                case DialogResult.Yes:
                    ReflectContract();
                    break;

                case DialogResult.No:
                    contractSetter1.Reset();
                    break;

                default:
                    break;
            }
            return true;
        }

        private void ReflectContract()
        {
            NowSelectedItem.Item = contractSetter1.ToContract();
            Binder.ResetBindings();
            IsChanged = true;
            contractSetter1.LoadContract(NowSelectedItem.Item);
        }

        private bool ShowSaveListDialog()
        {
            ShowSaveContractDialog();
            if (!IsChanged) return true;

            DialogResult res = MessageBox.Show(
                "条件リストの内容が変更されています。保存しますか？", "確認",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
            );
            switch (res)
            {
                case DialogResult.Cancel:
                    return false;

                case DialogResult.Yes:
                    return CallSaveForm();

                case DialogResult.No:
                    break;

                default:
                    break;
            }
            return true;
        }

        private void conditionSetter1_ConditionSaved(object sender, EventArgs e)
        {
            ReflectContract();
            //            contractSetter1.Reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowSaveContractDialog();
            CallSaveForm();
        }

        private bool CallSaveForm()
        {
            using (InputNameForm form = new InputNameForm())
            {
                form.Size = new System.Drawing.Size(320, 208);
                form.NowPreset = _nowPreset;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string fn = form.GetFileName();
                    SavePreset(fn);
                    IsChanged = false;
                    RefleshPresetBox();
                    comboBox1.SelectedItem = fn;

                    return true;
                }
            }
            return false;
        }

        private void SavePreset(string filepath)
        {
            List<Contract> list = new List<Contract>();
            foreach (ContractItem item in Binder.ToList())
            {
                list.Add(item.Item);
            }
            ContractList cl = new ContractList(list);
            var preset = new PresetController();
            preset.Write<ContractList>(filepath, cl);
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

        private void SetupCondList(ContractList list)
        {
            var bind = new Binder<ContractItem>(sortableListBox1);
            foreach (Contract item in list)
            {
                bind.Add(new ContractItem(item));
            }
            Binder = bind;
        }

        private string _nowPreset = "";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_nowPreset == comboBox1.Text) return;

            string new_preset = comboBox1.Text;
            if (ShowSaveListDialog())
            {
                if (new_preset.Length == 0)
                {
                    Binder.Clear();
                    _nowPreset = new_preset;
                    IsChanged = false;
                }
                else
                {
                    var preset = new PresetController();
                    ContractList n = ContractList.FromFile(preset.FindPath(new_preset));

                    if (n != null)
                    {
                        SetupCondList(n);
                        _nowPreset = new_preset;
                        IsChanged = false;
                    }
                    else
                    {
                        MessageBox.Show(
                            "指定されたプリセットファイルが存在しないため、使用できません。", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                    }
                }
            }
            comboBox1.SelectedItem = _nowPreset;
            sortableListBox1.SelectedIndex = -1;
            SetNowSelectedItem(null);
        }

        private void conditionSetter1_Load(object sender, EventArgs e)
        {
        }

        public UtauScore Score = null;

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (Score == null) throw new InvalidOperationException("Score is null.");
            if (!ShowSaveListDialog()) return;

            Score.ElementForEach((int key, UtauElement prev, UtauElement now, UtauElement next) =>
            {
                foreach (ContractItem var in Binder.ToList())
                {
                    // 条件に一致して変更が行われた場合は、以後の条件判定を行わない。
                    if (var.Item.Satisfy(now)) break;
                }
            });
            Score.output();
            this.Close();
        }

        private void sortableListBox1_OnAddRequest(object sender, EventArgs e)
        {
            AddNewFlagCondition();
        }

        private ContractItem NowSelectedItem;

        private void sortableListBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var now = Binder.SelectedItem;
            if (now == null || NowSelectedItem == now) return;
            if (!ShowSaveContractDialog()) return;
            SetNowSelectedItem(now);
            contractSetter1.LoadContract(now.Item);
        }

        private void SetNowSelectedItem(ContractItem now)
        {
            NowSelectedItem = now;
            SetEnabledEditPanel(now != null);
        }

        private void SetEnabledEditPanel(bool b)
        {
            contractSetter1.Enabled = b;
            button1.Enabled = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contractSetter1.Reset();
        }

        private void contractSetter1_OnChanged(object sender, ChangedEventArgs e)
        {
            buttonRun.Enabled = !e.Changed;
            label1.Visible = e.Changed;
            button1.Enabled = e.Changed;
            button2.Enabled = e.Changed;
        }
    }

    public class ContractItem : BindingItem<Contract>
    {
        public ContractItem(Contract item) : base(item)
        {
        }
    }
}