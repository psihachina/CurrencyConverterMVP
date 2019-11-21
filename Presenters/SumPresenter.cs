using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverterMVP.DAL;
using CurrencyConverterMVP.Models;
using CurrencyConverterMVP.Views;

namespace CurrencyConverterMVP.Presenters
{
    class SumPresenter: ISumPresenter
    {
        ILoggerRecording logger;
        BindingList<Valute> TopListValute;
        BindingList<Valute> BottomListValute;
        public ISumView SumView { get; set; }

        public SumPresenter(ISumView vs, BindingList<Valute> vl)
        {
            SumView = vs;
            TopListValute = new BindingList<Valute>(vl);
            BottomListValute = new BindingList<Valute>(vl);

            SumView.ListBox_Add(TopListValute, BottomListValute);
            SumView.LeftTextChange += View_LeftTextChange;
            SumView.RightTextChange += View_RightTextChange;
            SumView.SelectedLeftChanged += View_SelectedLeftChanged;
            SumView.SelectedRightChanged += View_SelectedRightChanged;
            SumView.Show();
        }

        private void View_SelectedRightChanged(object sender, EventArgs e)
        {
            if (SumView.SelectedRight != null)
            {
                if ((SumView.LeftValue != null) && (SumView.LeftValue != "")
                                               && (SumView.RightValue != null) && (SumView.RightValue != ""))
                {
                    SumView.SumValue = Math.Round(((SumView.SelectedLeft.CurrentValue * double.Parse(SumView.LeftValue) / SumView.SelectedRight.CurrentValue) +
                                                   (SumView.SelectedRight.CurrentValue * double.Parse(SumView.RightValue) / SumView.SelectedRight.CurrentValue)), 2).ToString();

                    //logger.log($"Вычисление суммы Валют : {SumView.SelectedTop.CharCode} {SumView.SelectedTop.CurrentValue * double.Parse(SumView.TopValue)} + " +
                    //           $"{SumView.SelectedBottom.CharCode} {SumView.SelectedBottom.CurrentValue * double.Parse(SumView.BottomValue)} = " +
                    //           $"{SumView.SelectedRight.CharCode} {double.Parse(SumView.SumValue)}");
                }
                SumView.Change_SelectedValuteLeft();
            }
        }
        private void View_SelectedLeftChanged(object sender, EventArgs e)
        {
            if (SumView.SelectedRight != null)
            {
                if ((SumView.LeftValue != null) && (SumView.LeftValue != "")
                                                && (SumView.RightValue != null) && (SumView.RightValue != ""))
                {
                    SumView.SumValue = Math.Round(((SumView.SelectedLeft.CurrentValue * double.Parse(SumView.LeftValue) / SumView.SelectedRight.CurrentValue) +
                                                   (SumView.SelectedRight.CurrentValue * double.Parse(SumView.RightValue) / SumView.SelectedRight.CurrentValue)), 2).ToString();

                    //logger.log($"Вычисление суммы Валют : {SumView.SelectedTop.CharCode} {SumView.SelectedTop.CurrentValue * double.Parse(SumView.TopValue)} + " +
                    //           $"{SumView.SelectedBottom.CharCode} {SumView.SelectedBottom.CurrentValue * double.Parse(SumView.BottomValue)} = " +
                    //           $"{SumView.SelectedRight.CharCode} {double.Parse(SumView.SumValue)}");
                }
            }
        }

        private void View_RightTextChange(object sender, EventArgs e)
        {
            if (SumView.SelectedRight != null)
            {
                if ((SumView.LeftValue != null) && (SumView.LeftValue != "")
                                                && (SumView.RightValue != null) && (SumView.RightValue != ""))
                {
                    SumView.SumValue = Math.Round(((SumView.SelectedLeft.CurrentValue * double.Parse(SumView.LeftValue) / SumView.SelectedRight.CurrentValue) +
                                                   (SumView.SelectedRight.CurrentValue * double.Parse(SumView.RightValue) / SumView.SelectedRight.CurrentValue)), 2).ToString();

                    //logger.log($"Вычисление суммы Валют : {SumView.SelectedTop.CharCode} {SumView.SelectedTop.CurrentValue * double.Parse(SumView.TopValue)} + " +
                    //           $"{SumView.SelectedBottom.CharCode} {SumView.SelectedBottom.CurrentValue * double.Parse(SumView.BottomValue)} = " +
                    //           $"{SumView.SelectedRight.CharCode} {double.Parse(SumView.SumValue)}");
                }
            }
        }
        private void View_LeftTextChange(object sender, EventArgs e)
        {
            if (SumView.SelectedRight != null)
            {
                if ((SumView.LeftValue != null) && (SumView.LeftValue != "")
                                                && (SumView.RightValue != null) && (SumView.RightValue != ""))
                {
                    SumView.SumValue = Math.Round(((SumView.SelectedLeft.CurrentValue * double.Parse(SumView.LeftValue) / SumView.SelectedRight.CurrentValue) +
                                                   (SumView.SelectedRight.CurrentValue * double.Parse(SumView.RightValue) / SumView.SelectedRight.CurrentValue)), 2).ToString();

                    //logger.log($"Вычисление суммы Валют : {SumView.SelectedTop.CharCode} {SumView.SelectedTop.CurrentValue * double.Parse(SumView.TopValue)} + " +
                    //           $"{SumView.SelectedBottom.CharCode} {SumView.SelectedBottom.CurrentValue * double.Parse(SumView.BottomValue)} = " +
                    //           $"{SumView.SelectedRight.CharCode} {double.Parse(SumView.SumValue)}");
                }
            }
        }


    }


}
