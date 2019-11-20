

using CurrencyConverter.Model;
using CurrencyConverterMVP.DAL;
using CurrencyConverterMVP.Models;
using CurrencyConverterMVP.Views;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Media;

namespace CurrencyConverterMVP.Presenters
{
    class ChartPresenter : IChartPresenter
    {
        public IChartView ChartView { get; set; }

        public ChartValues<DateModel> Values1 = new ChartValues<DateModel>();
        public SeriesCollection SeriesCollection { get; private set; }
        private Valute SelectedValute;

        public ChartPresenter(IChartView chartView, IValutesService valutesService)
        {
            ChartView = chartView;
            LoadAllFiles();
            ChartView.ListBoxHistory_Add(ValutesCurs[0].Valutes);

            var dayConfig = Mappers.Xy<DateModel>()
                .X(dateModel => dateModel.DateTime.Ticks / TimeSpan.FromDays(1).Ticks)
                .Y(dateModel => dateModel.Value);

            SeriesCollection = new SeriesCollection(dayConfig)
            {
                new LineSeries
                {
                    Title = "Change Valute",
                    Values = Values1,
                    Fill = Brushes.Transparent,
                }
            };

            ChartView.SelectedValutes += View_SelectedValute;
            ChartView.Show();
        }

        public Func<double, string> Formatter { get; set; }
        public BindingList<ValCurs> ValutesCurs = new BindingList<ValCurs>();



        private void LoadAllFiles()
        {
            string[] file_list = Directory.GetFiles("..\\CurrencyConverterMVP\\Content", "*.xml");
            int i = 0;
            foreach (string x in file_list)
            {
                ValutesCurs.Add(new LocalValuteService().GetValutes(file_list[i]));
                i++;
            }
            i = 0;
        }

        private void View_SelectedValute(object sender, EventArgs e)
        {
            ChartView.Click_SelectedValute(out SelectedValute);
            int i = 0;
            foreach (Valute x in ValutesCurs[0].Valutes)
            {
                if (x.CharCode != SelectedValute.CharCode)
                    i++;
                if (x.CharCode == SelectedValute.CharCode)
                    break;
            }
            Chart(i);
            ChartView.Change_Chart(SeriesCollection);
        }

        private void Chart(int k)
        {
            Values1.Clear();
            for (int i = 0; i < ValutesCurs.Count - 1; i++)
            {
                Values1.Add
                (
                    new DateModel
                    {
                        Value = Convert.ToDouble(ValutesCurs[i].Valutes[k].Value),
                        DateTime = Convert.ToDateTime(ValutesCurs[i].StringDate)
                    }
                ); ;
            }
        }
    }
}