using CurrencyConverterMVP.Models;
using CurrencyConverterMVP.Patterns;
using System.Net;

namespace CurrencyConverterMVP.DAL
{
    public class WebValuteService : IValutesService
    {
        public ValCurs GetValutes(string path)
        {
            //создание web клиента для http запросов
            var wc = new WebClient();
            //адрес для получения XML-файла с сайта ЦентроБанка
            var url = "https://www.cbr-xml-daily.ru/daily.xml";
            //загрузка файла
            var str = wc.DownloadString(url);
            return Xml.LoadObjectFromString<ValCurs>(str);
        }

    }
}
