using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ICalCreator
{
  public static class ICalCreator
  {
    public static byte[] CreateIcal()
    {
      iCalendar iCal = new iCalendar();
      WebClient webClient = new WebClient();
      webClient.Encoding = Encoding.UTF8;
      string[] items = webClient.DownloadString("http://dahermansson.github.io/ical/live.txt" + "?ticks=" + DateTime.Now.Ticks.ToString()).Split('$');

      foreach (string item in items)
      {
        if (items.Length == 0)
          continue;
        var parsedItem = ItemBL.CreateItem(item);
        if (parsedItem != null)
          iCal.Events.Add(ItemBL.ToEvent(parsedItem));
      }

      iCalendarSerializer serializer = new iCalendarSerializer();
      string result = serializer.SerializeToString(iCal);

      byte[] bytes = Encoding.UTF8.GetBytes(result);

      return bytes;
    }


  }
}
