using System;
using System.Xml.Serialization;

namespace Converter.Model
{
    [XmlRoot("Log")]
    public class Logger
    {
        [XmlIgnore]
        public DateTime dateTime { get; set; }

        [XmlAttribute("Message")]
        public string message { get; set; }

        [XmlAttribute("Date")]
        public string StringDate
        {
            get => dateTime.ToString();
            set => dateTime = DateTime.Parse(value);
        }

        public override string ToString()
        {
            return $"Дата и время : {dateTime.ToString()} ; \n Действие : {message} ; \n\n ";
        }
    }
}
