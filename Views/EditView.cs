using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurrencyConverterMVP.Models;

namespace CurrencyConverterMVP.Views
{
    public partial class EditView : Form, IEditView
    {
        public EditView()
        {
            InitializeComponent();
        }

        public Valute SelectedValute
        {
            get => listBox1.SelectedItem as Valute;
            set => listBox1.SelectedItem = value;
        }

        public string Value 
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        public void ListBoxValuteLeft_Add(BindingList<Valute> val)
        {
            listBox1.DataSource = val;
        }

        public event EventHandler TextChangedValue
        {
            add => textBox1.TextChanged += value;
            remove => textBox1.TextChanged -= value;
        }

        public event EventHandler SelectedEditValute
        {
            add => listBox1.SelectedIndexChanged += value;
            remove => listBox1.SelectedIndexChanged -= value;
        }
    }
}
