using System;
using System.ComponentModel;
using CurrencyConverterMVP.Models;
using CurrencyConverterMVP.Views;

namespace CurrencyConverterMVP.Presenters
{
    public class EditPresenter : IEditPresenter
    {
        public IEditView EditView { get; set; }
        BindingList<Valute> EditValuteList1;
        BindingList<Valute> EditValuteList2;
        BindingList<Valute> bufList;

        public EditPresenter(IEditView ve, BindingList<Valute> LVal, BindingList<Valute> RVal)
        {
            EditValuteList1 = LVal;
            bufList = RVal;
            EditView = ve;
            EditView.Value = "1";
            EditView.ListBoxValuteLeft_Add(EditValuteList1);

            EditView.TextChangedValue += View_TextChangeValue;
            EditView.SelectedEditValute += View_SelectedValuteEdit;

            EditView.Show();
        }

        private void View_TextChangeValue(object sender, EventArgs e)
        {
            EditView.SelectedValute.Value = EditView.Value;
            foreach (var valute in bufList)
            {
                if (EditView.SelectedValute.CharCode == valute.CharCode) valute.Value = EditView.SelectedValute.Value;
            }
        }

        private void View_SelectedValuteEdit(object sender, EventArgs e)
        {
            EditView.Value = EditView.SelectedValute.Value;
        }

    }
}