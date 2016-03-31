using DDay.iCal;
using DDay.iCal.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DDay.iCal.Serialization.iCalendar;
using System.Net;

namespace icalParser
{
  class Program
  {
    static void Main(string[] args)
    {
      iCalendar iCal = new iCalendar();
      WebClient webClient = new WebClient();
      webClient.Encoding = Encoding.UTF8;
      string[] items = webClient.DownloadString("http://dahermansson.github.io/ical/test.txt").Split('$');

      foreach (string item in items)
      {
        if (items.Length == 0)
          continue;
        var parsedItem = ItemBL.CreateItem(item);
        if(parsedItem != null)
          iCal.Events.Add(ItemBL.ToEvent(parsedItem));
      }
        
      iCalendarSerializer serializer = new iCalendarSerializer();
      string result = serializer.SerializeToString(iCal);

      byte[] bytes = Encoding.UTF8.GetBytes(result);

      File.Create("test.ics").Write(bytes, 0, bytes.Length);
    }
    
  }
}
