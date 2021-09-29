using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace utau_overflags.Forms
{
    public class Binder<T>
    {
        private readonly SortableListBox List;
        public Binder(SortableListBox _list)
        {
            List = _list;
            List.SetupDataSource(_datasource);
        }

        private BindingList<object> _datasource = new BindingList<object>();
        public BindingList<object> DataSource { get { return _datasource; } }
        public void Add(T item)
        {
            _datasource.Add(item);
            List.UpdateList();
        }

        public List<T> ToList()
        {
            var list = new List<T>();
            foreach (var item in DataSource)
            {
                list.Add((T)item);
            }
            return list;
        }

        public void ResetBindings()
        {
            _datasource.ResetBindings();
            List.UpdateList();
        }

        public void Clear()
        {
            _datasource.Clear();
            List.UpdateList();
        }

        public T SelectedItem
        {
            get { return (T)List.SelectedItem; }
            set { List.SelectedItem = value; }
        }

        public int SelectedIndex
        {
            get { return List.SelectedIndex; }
            set { List.SelectedIndex = value; }
        }
    }
}
