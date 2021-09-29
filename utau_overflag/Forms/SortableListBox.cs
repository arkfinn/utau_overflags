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
    public partial class SortableListBox : UserControl
    {
        public SortableListBox()
        {
            InitializeComponent();
        }

        private BindingList<object> _datasource;

        public BindingList<object> DataSource
        {
            get { return _datasource; }
        }

        public void SetupDataSource(BindingList<object> value)
        {
            _datasource = value;
            _datasource.RaiseListChangedEvents = true;
            listBox1.DataSource = _datasource;
            UpdateListButtonsEnabled();
        }

        public object SelectedItem
        {
            get { return listBox1.SelectedItem; }
            set { listBox1.SelectedItem = value; }
        }

        public int SelectedIndex
        {
            get { return listBox1.SelectedIndex; }
            set { listBox1.SelectedIndex = value; }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null) return;
            RemoveItem(SelectedItem);
        }

        private void btnListUp_Click(object sender, EventArgs e)
        {
            UpItem(listBox1.SelectedIndex);
        }

        private void btnListDown_Click(object sender, EventArgs e)
        {
            DownItem(listBox1.SelectedIndex);
        }

        public event EventHandler OnRemoved = (s, e) => { };
        private void RemoveItem(object item)
        {
            DataSource.Remove(item);
            UpdateListButtonsEnabled();
            OnRemoved.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnMoved = (s, e) => { };
        private void UpItem(int targetIndex)
        {
            MoveItem(targetIndex, targetIndex - 1);
        }

        private void DownItem(int targetIndex)
        {
            MoveItem(targetIndex, targetIndex + 1);
        }

        private void MoveItem(int targetIndex, int movetoIndex)
        {
            if (Math.Min(targetIndex, movetoIndex) < 0) return;
            if (Math.Max(targetIndex, movetoIndex) >= DataSource.Count) return;

            var target = DataSource[targetIndex];
            DataSource.Remove(target);
            DataSource.Insert(movetoIndex, target);
            listBox1.SelectedIndex = movetoIndex;

            UpdateListButtonsEnabled();
            OnMoved.Invoke(this, EventArgs.Empty);
        }

        private int _MinimumCount = 1;
        public int MinimumCount
        {
            get { return _MinimumCount; }
            set
            {
                _MinimumCount = value;
            }
        }

        private void UpdateListButtonsEnabled()
        {
            var enabled_delete = (MinimumCount < DataSource.Count);
            if (1 < DataSource.Count)
            {
                SetButtonsEnabled(enabled_delete, (0 < listBox1.SelectedIndex), (listBox1.SelectedIndex < DataSource.Count - 1));
            }
            else
            {
                SetButtonsEnabled(enabled_delete, false, false);
            }
        }

        private void SetButtonsEnabled(bool delete, bool up, bool down)
        {
            btnDelete.Enabled = delete;
            btnUp.Enabled = up;
            btnDown.Enabled = down;
        }
        public event EventHandler OnAddRequest = (s, e) => { };

        private void btnNew_Click(object sender, EventArgs e)
        {
            OnAddRequest.Invoke(this, EventArgs.Empty);
            UpdateListButtonsEnabled();
        }

        public event EventHandler OnSelectedIndexChanged = (s, e) => { };
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedIndexChanged(sender, e);
            UpdateListButtonsEnabled();
        }

        public event EventHandler OnListDoubleClicked = (s, e) => { };
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            OnListDoubleClicked(sender, e);
        }

        public void UpdateList()
        {
            UpdateListButtonsEnabled(); 
        }
    }
}
