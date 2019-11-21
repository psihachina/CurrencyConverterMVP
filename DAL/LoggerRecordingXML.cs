using Converter.Model;
using System;
using System.IO;
using System.Xml.Linq;

namespace CurrencyConverterMVP.DAL
{
    public class LoggerRecordingXML : ILoggerRecording
    {
        public void log(string mes)
        {
            Logger lg = new Logger();
            lg.dateTime = DateTime.Now;
            lg.message = mes;
            const string path = @"D:\Project\CurrencyConverterMVP\CurrencyConverterMVP\logger.xml";
            XElement element = null;
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                element = XElement.Load(stream);
            }
            element.Add(new XElement("Log",
                new XElement("DateTime", lg.dateTime.ToString()),
                new XElement("Message", lg.message)
                ));
            element.Save(path);
        }
    }
}
