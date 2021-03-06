﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDay.iCal;

namespace ICalCreator
{
  public class ItemBL
  {
    //StartDate;EndDate;Summary;Location;Description;
    private const int splits = 6;
    public static Item CreateItem(string row)
    {
      var item = new Item();
      string[] split = row.Split(';');
      if (split.Length != splits)
        return null;

      DateTime tempDateTime = DateTime.MinValue;

      if (!DateTime.TryParse(split[0], out tempDateTime))
        return null;
      item.StartDate = tempDateTime;
      item.EndDate = ParseEndDate(item.StartDate, split[1]);
      item.Summary = split[2];
      item.Location = split[3];
      item.Description = split[4].Replace("\n","\\n");
      return item;
    }

    public static Event ToEvent(Item item)
    {
      Event evt = new Event();
      evt.Start = new iCalDateTime(item.StartDate, "W. Europe Standard Time");
      evt.End = new iCalDateTime(item.EndDate, "W. Europe Standard Time");
      evt.Summary = item.Summary;
      evt.Location = item.Location;
      evt.Description = item.Description;
      return evt;
    }

    private static DateTime ParseEndDate(DateTime startDate, string end)
    {
      if (end.Length == 0 && startDate.Hour == 0)
        return startDate;
      if (end.Length == 0)
        return startDate.AddHours(3); //Default to 3h
      double parsedHour;
      if (double.TryParse(end, NumberStyles.Number, CultureInfo.CreateSpecificCulture("SV-se"), out parsedHour))
      {
        if (startDate.Hour == 0)
          return startDate;
        return startDate.AddHours(parsedHour);
      }
      DateTime parsedDate;
      if (DateTime.TryParse(end, out parsedDate))
      {
        return parsedDate;
      }
      return startDate;
    }

  }
}
