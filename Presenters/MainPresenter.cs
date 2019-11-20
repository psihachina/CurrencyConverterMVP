using CurrencyConverter.Model;
using CurrencyConverterMVP.DAL;
using CurrencyConverterMVP.Models;
using CurrencyConverterMVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverterMVP.Presenters
{
    class MainPresenter : IPresenter
    {


        private List<Valute> _valutesLeft;
        private List<Valute> _valutesRight;
        IValutesService valutesService;
        public IMainView MainView { get; set; }

        public bool IsStartCalculte { get; private set; }

        private Valute _selectedValuteLeft;
        private Valute _selectedValuteRight;
        private double _selectedValueLeft;
        private double _selectedValueRight;
        private HistoryItem _selectedHistoryItem;
        private History history = new History();

        public MainPresenter(IMainView mainView, IValutesService valutesService)
        {
            MainView = mainView;
            _valutesLeft = new List<Valute>
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
            _valutesLeft = _valutesLeft.Union(valsLeft.Valutes).ToList();
            _valutesRight = new List<Valute>(_valutesLeft);



            _selectedValuteLeft = _valutesLeft[0];
            _selectedValuteRight = _valutesLeft[0];

            MainView.ListBoxValuteLeft_Add(_valutesLeft);
            MainView.ListBoxValuteRight_Add(_valutesRight);

            MainView.ListBoxHistory_Add(history.Histories);
            MainView.OpenChart += View_OpenChart;
            MainView.SelectedValuteLeft += View_SelectedValuteLeft;
            MainView.SelectedValuteRight += View_SelectedValuteRight;
            MainView.TextChangedLeft += View_TextChangedLeft;
            MainView.TextChangedRight += View_TextChangedRight;
            MainView.SelectedHistory += View_SelectedHistory;
            MainView.Show();
        }

        private void View_SelectedHistory(object sender, EventArgs e)
        {
            MainView.Click_SelectedHistory(out _selectedHistoryItem);

            _selectedValueLeft = _selectedHistoryItem.FirstValue;
            _selectedValuteRight = _selectedHistoryItem.SecondValute;
            _selectedValueRight = _selectedHistoryItem.SecondValue;
            _selectedValuteLeft = _selectedHistoryItem.FirstValute;


        }

        private void View_OpenChart(object sender, EventArgs e)
        {
            new ChartPresenter(new ChartView(), new LocalValuteService());
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
                if (last == null || (((last.FirstValue != _selectedValueLeft) || (last.SecondValue != _selectedValueRight))
                                     || ((last.FirstValute != _selectedValuteLeft) || (last.SecondValute != _selectedValuteRight))))
                    history.Histories.Add(item);
                MainView.ListBoxHistory_Add(history.Histories);
            }
            else
            {
                history.Histories.Add(item);
                MainView.ListBoxHistory_Add(history.Histories);
            }
        }

        private void AddHistoryLeft()
        {
            // logger.Write("Add left history");

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
                if (last == null || (((last.FirstValue != _selectedValueLeft) || (last.SecondValue != _selectedValueRight))
                                     || ((last.FirstValute != _selectedValuteLeft) || (last.SecondValute != _selectedValuteRight))))
                    history.Histories.Add(item);
            }
            else
            {
                history.Histories.Add(item);
            }
        }







    }
}
