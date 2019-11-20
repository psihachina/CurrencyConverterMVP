using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CurrencyConverterMVP.Models
{
    [XmlRoot("ValCurs")]
    public class ValCurs
    {
        [XmlIgnore]
        public DateTime Date { get; set; }
        [XmlAttribute("Date")]
        public string StringDate
        {
            get => Date.ToString();
            set => Date = DateTime.Parse(value);
        }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("Valute")]
        public BindingList<Valute> Valutes { get; set; }
    }
}
