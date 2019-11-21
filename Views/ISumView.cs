using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurrencyConverterMVP.Models;

namespace CurrencyConverterMVP.Views
{
    public interface ISumView : IView
    {
        string LeftValue { get; set; }
        string RightValue { get; set; }
        string SumValue { get; set; }
        Valute SelectedRight { get; set; }
        Valute SelectedLeft { get; set; }

        event EventHandler LeftTextChange;
        event EventHandler RightTextChange;
        event EventHandler SelectedLeftChanged;
        event EventHandler SelectedRightChanged;

        void ListBox_Add(BindingList<Valute> top, BindingList<Valute> bottom);
        void Change_SelectedValuteLeft();
    }
}
