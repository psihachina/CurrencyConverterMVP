using CurrencyConverter.Model;
using CurrencyConverterMVP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CurrencyConverterMVP.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public new void Show() => Application.Run(this);

        public double ValueLeft
        {
            get => Convert.ToDouble(valueLeft.Text);
            set => valueLeft.Text = value.ToString();
        }
        public double ValueRight
        {
            get => Convert.ToDouble(valueRight.Text);
            set => valueRight.Text = value.ToString();
        }

        public event EventHandler OpenChart
        {
            add => chartsToolStripMenuItem.Click += value;
            remove => chartsToolStripMenuItem.Click -= value;
        }

        public event EventHandler SelectedHistory
        {
            add => listBox3.SelectedIndexChanged += value;
            remove => listBox3.SelectedIndexChanged -= value;
        }

        public event EventHandler SelectedValuteLeft
        {
            add => ValutesLeft.SelectedIndexChanged += value;
            remove => ValutesLeft.SelectedIndexChanged -= value;
        }

        public event EventHandler SelectedValuteRight
        {
            add => ValutesRight.SelectedIndexChanged += value;
            remove => ValutesRight.SelectedIndexChanged -= value;
        }

        public event EventHandler TextChangedLeft
        {
            add => valueLeft.TextChanged += value;
            remove => valueLeft.TextChanged -= value;
        }
        public event EventHandler TextChangedRight
        {
            add => valueRight.TextChanged += value;
            remove => valueRight.TextChanged -= value;
        }


        public void ListBoxValuteLeft_Add(List<Valute> val)
        {
            ValutesLeft.DataSource = val;
            label1.Text = val[0].Name;
        }
        public void ListBoxValuteRight_Add(List<Valute> val)
        {
            ValutesRight.DataSource = val;
            label2.Text = val[0].Name;
        }

        public void ListBoxHistory_Add(BindingList<HistoryItem> val)
        {
            listBox3.DataSource = val;
        }

        public void Click_SelectedValuteLeft(out Valute leftValute)
        {
            leftValute = (Valute)ValutesLeft.SelectedItem;
            label1.Text = leftValute.Name;
        }

        public void Click_SelectedValuteRight(out Valute rightValute)
        {
            rightValute = (Valute)ValutesRight.SelectedItem;
            label2.Text = rightValute.Name;
        }

        public void Click_SelectedHistory(out HistoryItem hisitm)
        {
            hisitm = (HistoryItem)listBox3.SelectedItem;
            ValutesLeft.SelectedItem = hisitm.FirstValute;
            ValutesRight.SelectedItem = hisitm.SecondValute;
            label1.Text = hisitm.FirstValute.Name;
            label2.Text = hisitm.SecondValute.Name;
            valueLeft.Text = Convert.ToString(hisitm.FirstValue);
            valueRight.Text = Convert.ToString(hisitm.SecondValue);
        }

        public void Click_SelectedValueLeft(double rightValute)
        {

        }

        public void Click_SelectedValueRight(double rightValute)
        {

        }
    }
}
