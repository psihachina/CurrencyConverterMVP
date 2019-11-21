using CurrencyConverter.Model;
using CurrencyConverterMVP.DAL;
using CurrencyConverterMVP.Models;
using CurrencyConverterMVP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CurrencyConverterMVP.Presenters
{
    class MainPresenter : IPresenter
    {


        private BindingList<Valute> _valutesLeft;
        private BindingList<Valute> _valutesRight;
        IValutesService valutesService;
        public IMainView MainView { get; set; }

        private bool checkHistory = false;
        private Valute _selectedValuteLeft;
        private Valute _selectedValuteRight;
        private double _selectedValueLeft;
        private double _selectedValueRight;
        private HistoryItem _selectedHistoryItem;
        private History history = new History();
        ILoggerRecording logger;

        public MainPresenter(IMainView mainView, IValutesService valutesService, ILoggerRecording lg)
        {
            logger = lg;
            MainView = mainView;
            _valutesLeft = new BindingList<Valute>
            {
                new Valute
                {CharCode = "RUS",
                    Nominal = 1,
                    Name = "Российский рубль",
                    NumCode = 0,
                    Value = "1",}
            };
            MainView.ValueLeft = 1.0;
            MainView.ValueRight = 1.0;


            this.valutesService = valutesService;
            var valsLeft = valutesService.GetValutes("./Content/daily_utf8.xml");
            List<Valute> buf = _valutesLeft.Union(valsLeft.Valutes).ToList();
            _valutesLeft = new BindingList<Valute>(buf); ;
            _valutesRight = new BindingList<Valute>(_valutesLeft);



            _selectedValuteLeft = _valutesLeft[0];
            _selectedValuteRight = _valutesLeft[0];

            MainView.ListBoxValuteLeft_Add(_valutesLeft);
            MainView.ListBoxValuteRight_Add(_valutesRight);

            MainView.ListBoxHistory_Add(history.Histories);
            MainView.OpenChart += View_OpenChart;
            MainView.OpenSum += View_OpenSum;
            MainView.OpenEdit += View_OpenEdit;
            MainView.SelectedValuteLeft += View_SelectedValuteLeft;
            MainView.SelectedValuteRight += View_SelectedValuteRight;
            MainView.TextChangedLeft += View_TextChangedLeft;
            MainView.TextChangedRight += View_TextChangedRight;
            MainView.SelectedHistory += View_SelectedHistory;
            logger.log("Открытие Программы");
            MainView.Show();
        }

        private void View_SelectedHistory(object sender, EventArgs e)
        {
            checkHistory = true;
            
                MainView.Click_SelectedHistory(out _selectedHistoryItem);

            _selectedValueLeft = _selectedHistoryItem.FirstValue;
            _selectedValuteRight = _selectedHistoryItem.SecondValute;
            _selectedValueRight = _selectedHistoryItem.SecondValue;
            _selectedValuteLeft = _selectedHistoryItem.FirstValute;

            checkHistory = false;
        }

        private void View_OpenChart(object sender, EventArgs e)
        {
            new ChartPresenter(new ChartView(), new LocalValuteService());
            logger.log("Открытие окна графика Валют");
        }
        private void View_OpenSum(object sender, EventArgs e)
        {
            new SumPresenter(new SumView(), _valutesLeft);
            logger.log("Открытие окна суммирования Валют");
        }

        private void View_OpenEdit(object sender, EventArgs e)
        {
            new EditPresenter(new EditView(), _valutesLeft, _valutesRight);
            logger.log("Открытие окна редактирования Валют");
        }


        private void View_SelectedValuteLeft(object sender, EventArgs e)
        {
            MainView.Click_SelectedValuteLeft(out _selectedValuteLeft);
            MainView.ValueRight = _selectedValuteLeft.CurrentValue * MainView.ValueLeft / _selectedValuteRight.CurrentValue;
        }
        private void View_SelectedValuteRight(object sender, EventArgs e)
        {
            MainView.Click_SelectedValuteRight(out _selectedValuteRight);
            MainView.ValueLeft = _selectedValuteRight.CurrentValue * MainView.ValueRight / _selectedValuteLeft.CurrentValue;
        }
        private void View_TextChangedLeft(object sender, EventArgs e)
        {
            _selectedValueLeft = MainView.ValueLeft;
            MainView.ValueRight = _selectedValuteLeft.CurrentValue * MainView.ValueLeft / _selectedValuteRight.CurrentValue;

            AddHistoryLeft();

        }
        private void View_TextChangedRight(object sender, EventArgs e)
        {
            _selectedValueRight = MainView.ValueRight;
            MainView.ValueLeft = _selectedValuteRight.CurrentValue * MainView.ValueRight / _selectedValuteLeft.CurrentValue;

            AddHistoryRight();

        }

        private void AddHistoryRight()
        {
            if (checkHistory == false)
            {
                logger.log($"Добавлена запись в историю");
                var item = new HistoryItem
                {
                    FirstValute = _selectedValuteLeft,
                    SecondValute = _selectedValuteRight,
                    FirstValue = MainView.ValueLeft,
                    SecondValue = MainView.ValueRight,
                    Direction = false,
                    DirectionString = " <- "
                };
                if (history.Histories.Count > 0)
                {
                    var last = history.Histories.Last();
                    if (last == null || (((last.FirstValue != _selectedValueLeft) ||
                                          (last.SecondValue != _selectedValueRight))
                                         || ((last.FirstValute != _selectedValuteLeft) ||
                                             (last.SecondValute != _selectedValuteRight))))
                        history.Histories.Add(item);
                    MainView.ListBoxHistory_Add(history.Histories);
                }
                else
                {
                    history.Histories.Add(item);
                    MainView.ListBoxHistory_Add(history.Histories);
                }
            }
        }

        private void AddHistoryLeft()
        {
            if (checkHistory == false)
            {
                logger.log($"Добавлена запись в историю");
                var item = new HistoryItem
                {
                    FirstValute = _selectedValuteLeft,
                    SecondValute = _selectedValuteRight,
                    FirstValue = MainView.ValueLeft,
                    SecondValue = MainView.ValueRight,
                    Direction = false,
                    DirectionString = " -> "
                };
                if (history.Histories.Count > 0)
                {
                    var last = history.Histories.Last();
                    if (last == null || (((last.FirstValue != _selectedValueLeft) ||
                                          (last.SecondValue != _selectedValueRight))
                                         || ((last.FirstValute != _selectedValuteLeft) ||
                                             (last.SecondValute != _selectedValuteRight))))
                        history.Histories.Add(item);
                }
                else
                {
                    history.Histories.Add(item);
                }
            }
        }







    }
}
