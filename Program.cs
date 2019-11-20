using CurrencyConverterMVP.DAL;
using CurrencyConverterMVP.Presenters;
using CurrencyConverterMVP.Views;
using System;
using System.Windows.Forms;

namespace CurrencyConverterMVP
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                new MainPresenter(new MainView(), new WebValuteService());
            }
            catch
            {
                new MainPresenter(new MainView(), new LocalValuteService());
            }
        }
    }
}
