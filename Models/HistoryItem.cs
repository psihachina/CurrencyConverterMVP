using CurrencyConverterMVP.Models;
using System.Xml.Serialization;

namespace CurrencyConverter.Model
{
    [XmlRoot("History")]

    public class HistoryItem
    {
        public bool Direction { get; set; }
        public Valute FirstValute { get; set; }
        public Valute SecondValute { get; set; }
        public double FirstValue { get; set; }
        public double SecondValue { get; set; }
        public string DirectionString { get; set; }

        public override string ToString()
        {
            return $"{FirstValue} {FirstValute.CharCode} {DirectionString} {SecondValue} {SecondValute.CharCode}";
        }
    }
}
