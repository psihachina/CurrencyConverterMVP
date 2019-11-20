using CurrencyConverterMVP.Models;
using CurrencyConverterMVP.Patterns;

namespace CurrencyConverterMVP.DAL
{
    class LocalValuteService : IValutesService
    {
        public ValCurs GetValutes(string path)
        {
            return Xml.LoadObjectFromFile<ValCurs>(path);
        }


    }
}
