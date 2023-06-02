using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using utau_overflags.Conditions;
using utau_overflags.Edits;

namespace utau_overflags.Forms
{
    public partial class ContractSetter : UserControl
    {
        public ContractSetter()
        {
            InitializeComponent();
            ConditionBinder = new Binder<ConditionItem>(listConditions);
            EditBinder = new Binder<EditItem>(listEdits);
        }
        private bool IsChanged = false;
        public bool Changed { get { return IsChanged; } }
        public void LoadContract(Contract from)
        {
            Base = from;
            Reset();
        }

        private Contract Base = null;
        private Binder<ConditionItem> ConditionBinder;
        private Binder<EditItem> EditBinder;

        public Contract ToContract()
        {
            return new Contract(CreateConditionList(), CreateEditList());
        }

        private List<CondBase> CreateConditionList()
        {
            var list = new List<CondBase>();
            foreach (var i in ConditionBinder.ToList())
            {
                list.Add(i.Item);
            }
            return list;
        }

        private List<EditBase> CreateEditList()
        {
            var list = new List<EditBase>();
            foreach (var i in EditBinder.ToList())
            {
                list.Add(i.Item);
            }
            return list;
        }

        public void Reset()
        {
            //Baseを元に初期化
            ResetConditions();
            ResetEdits();
            InvokeChanged(false);
        }

        private void ResetConditions()
        {
            ConditionBinder.Clear();
            foreach (CondBase cond in Base.Conditions)
            {
                ConditionBinder.Add(new ConditionItem(cond));
            }
        }

        private void ResetEdits()
        {
            EditBinder.Clear();
            foreach (EditBase edit in Base.Edits)
            {
                EditBinder.Add(new EditItem(edit));
            }
        }

        private void listConditions_OnListDoubleClicked(object sender, EventArgs e)
        {
            var item = CallConditionEditDialog(ConditionBinder.SelectedItem.Item);
            if (item == null) return;

            ConditionBinder.SelectedItem.Item = item;
            ConditionBinder.ResetBindings();
            InvokeChanged(true);
        }

        private void listEdits_OnListDoubleClicked(object sender, EventArgs e)
        {
            var item = CallEditEditDialog(EditBinder.SelectedItem.Item);
            if (item == null) return;

            EditBinder.SelectedItem.Item = item;
            EditBinder.ResetBindings();
            InvokeChanged(true);
        }

        private CondBase CallConditionEditDialog(CondBase item)
        {
            return new ConditionControlProvider(item).Call("条件の設定");
        }

        private EditBase CallEditEditDialog(EditBase item)
        {
            return new EditControlProvider(item).Call("編集内容の設定");
        }

        private Form CreateForm(string title, Size size)
        {
            var form = new Form();
            form.Text = title;
            form.Size = size;
            form.StartPosition = FormStartPosition.CenterParent;
            
            return form;
        }

        private void listConditions_OnAddRequest(object sender, EventArgs e)
        {
            using (var form = CreateForm("条件の新規追加", new Size(400, 280)))
            {
                var panel = new ConditionPanel();
                form.Height = panel.Height + 40;
                panel.Dock = DockStyle.Fill;
                panel.OnButtonClicked += (s, args) =>
                {
                    var item = CallConditionEditDialog(args.Condition);
                    if (item != null)
                    {
                        ConditionBinder.Add(new ConditionItem(item));
                        ConditionBinder.ResetBindings();
                        InvokeChanged(true);
                    }
                    form.Close();
                };
                form.Controls.Add(panel);
                form.ShowDialog();
            }
        }

        private void listEdits_OnAddRequest(object sender, EventArgs e)
        {
            using (var form = CreateForm("編集内容の新規追加", new Size(400, 360)))
            {
                var panel = new EditPanel();
                form.Height = panel.Height + 40;
                panel.Dock = DockStyle.Fill;
                panel.OnButtonClicked += (s, args) =>
                {
                    var item = CallEditEditDialog(args.Edit);
                    if (item != null)
                    {
                        EditBinder.Add(new EditItem(item));
                        EditBinder.ResetBindings();
                        InvokeChanged(true);
                    }
                    form.Close();
                };
                form.Controls.Add(panel);
                form.ShowDialog();
            }
        }

        private void OnListChanged(object sender, EventArgs e)
        {
            InvokeChanged( true);
        }

        public event EventHandler<ChangedEventArgs> OnChanged = (s, e) => { };
        private void InvokeChanged(bool changed)
        {
            IsChanged = changed;
            OnChanged.Invoke(this, new ChangedEventArgs(changed));
        }
    }

    public class ChangedEventArgs :EventArgs
    {
        public readonly bool Changed;
        public ChangedEventArgs(bool changed)
        {
            Changed = changed;
        }
    }

    public class ConditionItem : BindingItem<CondBase>
    {
        public ConditionItem(CondBase item) : base(item) { }
    }

    public class EditItem : BindingItem<EditBase>
    {
        public EditItem(EditBase item) : base(item) { }
    }
}
