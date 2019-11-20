using CurrencyConverterMVP.Models;
using LiveCharts;
using System;
using System.ComponentModel;

namespace CurrencyConverterMVP.Views
{
    public interface IChartView : IView
    {
        event EventHandler SelectedValutes;
        void ListBoxHistory_Add(BindingList<Valute> val);
        void Click_SelectedValute(out Valute valute);
        void Change_Chart(SeriesCollection seriesCollection);
    }
}
