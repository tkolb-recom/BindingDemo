using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BindingDemo
{
    public partial class Form1 : Form
    {
        private readonly TextSource _sourceInstance;

        public Form1()
        {
            InitializeComponent();

            _sourceInstance = new TextSource();
            _sourceInstance.PropertyChanged += PropertyChangedHandler;
            
            textBox1.BindTo(_sourceInstance, box => box.Text, source => source.Text);
            //, dataSourceUpdateMode: DataSourceUpdateMode.OnValidation

            errorProvider1.DataSource = _sourceInstance;
        }

        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            listBox1.Items.Add($"{DateTime.Now.ToLongTimeString()} {sender.GetType().Name}.{e.PropertyName}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_sourceInstance.Text);
        }
    }
}
