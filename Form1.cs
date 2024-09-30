using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BindingDemo
{
    public partial class Form1 : Form
    {
        private readonly ParentSource _sourceInstance;

        public Form1()
        {
            InitializeComponent();

            _sourceInstance = new ParentSource();
            _sourceInstance.PropertyChanged += PropertyChangedHandler;
            _sourceInstance.Nested.PropertyChanged += PropertyChangedHandler;

            textBox1.BindTo(_sourceInstance.Nested, box => box.Text, source => source.Text);
            //, dataSourceUpdateMode: DataSourceUpdateMode.OnValidation

            errorProvider1.DataSource = _sourceInstance.Nested;
        }

        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            listBox1.Items.Add($"{DateTime.Now.ToLongTimeString()} {sender.GetType().Name}.{e.PropertyName}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_sourceInstance.Nested.Text);
        }
    }
}
