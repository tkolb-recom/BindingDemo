using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BindingDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            bindingSource1.AddingNew += (s, ev) => Write("AddingNew");
            bindingSource1.BindingComplete += (s, ev) => Write("BindingComplete");
            bindingSource1.CurrentChanged += (s, ev) => Write("CurrentChanged");
            bindingSource1.CurrentItemChanged += (s, ev) => Write("CurrentItemChanged");
            bindingSource1.DataError += (s, ev) => Write("DataError");
            bindingSource1.DataMemberChanged += (s, ev) => Write("DataMemberChanged");
            bindingSource1.DataSourceChanged += (s, ev) => Write("DataSourceChanged");
            bindingSource1.ListChanged += (s, ev) => Write("ListChanged");
            bindingSource1.PositionChanged += (s, ev) => Write("PositionChanged");

            bindingSource1.Add(new TextSource { Text = "John" });
            bindingSource1.Add(new TextSource { Text = "Jill" });
            bindingSource1.Add(new TextSource { Text = "Jack" });
            bindingSource1.Add(new TextSource { Text = "Joan" });
        }

        private void Write(string text)
        {
            listBox1.Items.Add($"{DateTime.Now.ToLongTimeString()} {text}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((TextSource)bindingSource1.Current).Text);
        }
    }
}