using System.ComponentModel;
using System.Xml.Serialization;

namespace CurrencyConverter.Model
{
    [XmlRoot("History")]

    public class History
    {
        [XmlElement("HistoryItem")]

        private BindingList<HistoryItem> _histories;

        public BindingList<HistoryItem> Histories
        {
            get { return _histories; }
            set { _histories = value; }
        }
        public History()
        {
            _histories = new BindingList<HistoryItem>();
        }


    }


}
