using CurrencyConverterMVP.Views;

namespace CurrencyConverterMVP.Presenters
{
    public interface IChartPresenter
    {
        IChartView ChartView { get; set; }
    }
}