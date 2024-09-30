using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var ps = new ParentSource();
            ps.PropertyChanged += PropertyChangedHandler;
            ps.Nested.PropertyChanged += PropertyChangedHandler;
            textSourceBindingSource.DataSource = ps.Nested;
        }

        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            listBox1.Items.Add($"{DateTime.Now.ToLongTimeString()} {sender.GetType().Name}.{e.PropertyName}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = ((TextSource)textSourceBindingSource.DataSource).Text;
            MessageBox.Show(text);
        }
    }
}
