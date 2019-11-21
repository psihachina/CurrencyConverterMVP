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
    public partial class SumView : Form, ISumView
    {
        public SumView()
        {
            InitializeComponent();
        }

        public string LeftValue
        {
            get => ValueLeftBox.Text;
            set => ValueLeftBox.Text = value;
        }
        public string RightValue
        {
            get => ValueRightBox.Text;
            set => ValueRightBox.Text = value;
        }
        public Valute SelectedLeft
        {
            get => ValuteLeftComboBox.SelectedItem as Valute;
            set => ValuteLeftComboBox.SelectedItem = value;
        }
        public Valute SelectedRight
        {
            get => ValuteRightComboBox.SelectedItem as Valute;
            set => ValuteRightComboBox.SelectedItem = value;
        }
        public string SumValue
        {
            get => SumLabel.Text;
            set => SumLabel.Text = value;
        }

        public event EventHandler LeftTextChange
        {
            add => ValueLeftBox.TextChanged += value;
            remove => ValueLeftBox.TextChanged -= value;
        }
        public event EventHandler RightTextChange
        {
            add => ValueRightBox.TextChanged += value;
            remove => ValueRightBox.TextChanged -= value;
        }
        public event EventHandler SelectedRightChanged
        {
            add => ValuteRightComboBox.SelectedIndexChanged += value;
            remove => ValuteRightComboBox.SelectedIndexChanged -= value;
        }

        public event EventHandler SelectedLeftChanged
        {
            add => ValuteLeftComboBox.SelectedIndexChanged += value;
            remove => ValuteLeftComboBox.SelectedIndexChanged -= value;
        }


        public void ListBox_Add(BindingList<Valute> top, BindingList<Valute> bottom)
        {
            ValuteLeftComboBox.DataSource = top;
            ValuteRightComboBox.DataSource = bottom;
        }

        public void Change_SelectedValuteLeft()
        {
            SumValuteLabel.Text = ValuteRightComboBox.SelectedItem.ToString();
        }
    }
}

