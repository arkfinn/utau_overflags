using NUnit.Extensions.Forms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using utau_overflagstest.Attributes;

namespace utau_overflags.Forms
{
    class SortableListBoxTest : ControlTestBase
    {
        [Test]
        public void SortableListBoxのDeleteボタンの動作()
        {
            var control = new SortableListBox();
            var list = CreateBinder(control);
            var form = CreateControlForm(control);
            FetchListBox(form).Select(1);
            new ButtonTester("SortableListBox.btnDelete", form).Click();

            ShouldBeCount(list.DataSource, 2);
        }

        private Form CreateControlForm(SortableListBox list)
        {
            return CreateForm(list);
        }

        private ListBoxTester FetchListBox(Form form)
        {
            return new ListBoxTester("SortableListBox.panel1.listBox1", form);

        }

        private Binder<string> CreateBinder(SortableListBox control)
        {
            var list = new Binder<string>(control);
            list.Add("aaa");
            list.Add("bbb");
            list.Add("ccc");
            ShouldBeCount(list.DataSource, 3);
            return list;
        }

        private void ShouldBeCount(IList<object> list, int expectedCount)
        {
            Assert.That(list.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void SortableListBoxのDownボタンの動作()
        {
            var control = new SortableListBox();
            var list = CreateBinder(control);
            var form = CreateControlForm(control);
            FetchListBox(form).Select(1);
            new ButtonTester("SortableListBox.btnDown", form).Click();

            ShouldBeCount(list.DataSource, 3);
            ShouldBeList(list.ToList(), "aaa,ccc,bbb");
        }

        [Test]
        public void SortableListBoxのUpボタンの動作()
        {
            var control = new SortableListBox();
            var list = CreateBinder(control);
            var form = CreateControlForm(control);
            FetchListBox(form).Select(1);
            new ButtonTester("SortableListBox.btnUp", form).Click();

            ShouldBeCount(list.DataSource, 3);
            ShouldBeList(list.ToList(), "bbb,aaa,ccc");
        }

        private void ShouldBeList(List<string> list, string expected)
        {
            Assert.That(string.Join(",", list.ToArray()), Is.EqualTo(expected));
        }
    }
}
