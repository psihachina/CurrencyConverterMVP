using CurrencyConverterMVP.Models;
using System.Collections.Generic;

namespace CurrencyConverterMVP.DAL
{
    public static class LocalSaveValuteService
    {
        public static void SaveValute(List<Valute> allvalutes)
        {
            /* int counter = 1;
             var xDoc = XDocument.Load(@"C:\Users\vlad0\Desktop\Programming\Учеба\АРХ ИС\lab 3\lab03v2\Converter\Converter\Content\daily_utf8.xml");
             XElement root = xDoc.Element("ValCurs");

             foreach(XElement xe in root.Elements("Valute").ToList())
             {
                 xe.Attribute("Nominal").Value = allvalutes[counter].Nominal.ToString();
                 xe.Attribute("Value").Value = allvalutes[counter].Value;
                 if(allvalutes.Count > counter)
                 {
                     counter++;
                 }
             }
             //XElement element = SerializationXML.Element("ValCurs");
             //foreach(var item in element.Elements("Valute").ToList())
             //{
             //    item.Element("Nominal").Value = allvalutes[count].Nominal.ToString();
             //    item.Element("Value").Value = allvalutes[count].Value;
             //    count++;
             //}

             xDoc.Save(@"C:\Users\vlad0\Desktop\Programming\Учеба\АРХ ИС\lab 3\lab03v2\Converter\Converter\Content\daily_" +
                 DateTime.Now.Year.ToString() + "-" +
                 DateTime.Now.Month.ToString() + "-" +
                 DateTime.Now.Day.ToString() + ":" +
                 DateTime.Now.Hour.ToString() + "-" +
                 DateTime.Now.Minute.ToString() + "-" +
                 DateTime.Now.Second.ToString() + ".xml");
                 */
        }
    }
}
