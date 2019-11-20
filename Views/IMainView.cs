using CurrencyConverter.Model;
using CurrencyConverterMVP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CurrencyConverterMVP.Views
{
    public interface IMainView : IView
    {
        double ValueLeft { get; set; }

        double ValueRight { get; set; }

        event EventHandler SelectedValuteLeft;
        event EventHandler SelectedValuteRight;
        event EventHandler TextChangedLeft;
        event EventHandler TextChangedRight;
        event EventHandler SelectedHistory;
        event EventHandler OpenChart;

        void Click_SelectedValuteLeft(out Valute leftValute);
        void Click_SelectedValuteRight(out Valute rightValute);
        void Click_SelectedValueLeft(double leftValue);
        void Click_SelectedValueRight(double rightValue);
        void Click_SelectedHistory(out HistoryItem hisitm);

        void ListBoxHistory_Add(BindingList<HistoryItem> val);

        void ListBoxValuteLeft_Add(List<Valute> val);
        void ListBoxValuteRight_Add(List<Valute> val);

    }
}
