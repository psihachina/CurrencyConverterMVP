using CurrencyConverterMVP.Views;

namespace CurrencyConverterMVP.Presenters
{
    public interface IPresenter
    {
        IMainView MainView { get; set; }
    }
}
