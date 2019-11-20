using System.Xml.Serialization;

namespace CurrencyConverterMVP.Models
{
    [XmlRoot("ValCurs")]
    public class Valute
    {
        public int NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        [XmlIgnore]
        public double CurrentValue => double.Parse(Value) / Nominal;

        public override string ToString()
        {
            return Name + " (" + CharCode + ")";
        }
    }
}
