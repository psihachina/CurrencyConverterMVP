using CurrencyConverterMVP.Models;

namespace CurrencyConverterMVP.DAL
{
    interface IValutesService
    {
        ValCurs GetValutes(string path);
    }
}
