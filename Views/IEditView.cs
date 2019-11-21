using System;
using System.ComponentModel;
using System.Windows.Forms;
using CurrencyConverterMVP.Models;

namespace CurrencyConverterMVP.Views
{
    public interface IEditView : IView
    {
        Valute SelectedValute { get; set; }
        string Value { get; set; }

        event EventHandler TextChangedValue;
        event EventHandler SelectedEditValute;
        void ListBoxValuteLeft_Add(BindingList<Valute> val);
    }
}