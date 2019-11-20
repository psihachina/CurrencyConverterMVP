using CurrencyConverter.Model;
using CurrencyConverterMVP.Models;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CurrencyConverterMVP.Views
{
    public partial class ChartView : Form, IChartView
    {
        public ChartView()
        {
            InitializeComponent();



        }
        public void ListBoxHistory_Add(BindingList<Valute> val)
        {
            listBox1.DataSource = val;
        }

        public event EventHandler SelectedValutes
        {
            add => listBox1.SelectedIndexChanged += value;
            remove => listBox1.SelectedIndexChanged -= value;
        }


        public void Click_SelectedValute(out Valute valute)
        {
            valute = (Valute)listBox1.SelectedItem;
        }

        public void Change_Chart(SeriesCollection seriesCollection)
        {
            cartesianChart1.LegendLocation = LegendLocation.Right;
            cartesianChart1.Series = seriesCollection;
            var dayConfig = Mappers.Xy<DateModel>()
                .X(dateModel => dateModel.DateTime.Ticks / (TimeSpan.FromDays(1).Ticks))
                .Y(dateModel => dateModel.Value);
            cartesianChart1.AxisX[0] = (new Axis
            {
                LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("d")
            });
        }
    }
}
