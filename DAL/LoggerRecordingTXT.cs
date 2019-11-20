using Converter.Model;
using System;
using System.IO;

namespace CurrencyConverterMVP.DAL
{
    public class LoggerRecordingTXT : ILoggerRecording
    {
        public void log(string mes)
        {
            Logger lg = new Logger();
            lg.dateTime = DateTime.Now;
            lg.message = mes;
            string path = @"C:\Users\vlad0\Desktop\Programming\Учеба\АРХ ИС\lab 3\lab03v2\Converter\Converter\Content\History\log.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(lg.ToString());
                sw.Close();
            }
        }
    }
}
