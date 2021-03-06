﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Mvc;
using ICalCreator;

namespace KalenderWeb.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult List()
    {
      WebClient webClient = new WebClient();
      webClient.Encoding = Encoding.UTF8;
      string[] items = webClient.DownloadString("http://dahermansson.github.io/ical/live.txt" + "?ticks=" + DateTime.Now.Ticks.ToString()).Split('$');
      List<Item> lItems = new List<Item>();
      foreach (string item in items)
      {
        if (items.Length == 0)
          continue;
        var parsedItem = ItemBL.CreateItem(item);
        if (parsedItem != null)
          lItems.Add(parsedItem);
      }
        return View(lItems);
    }

  }
}