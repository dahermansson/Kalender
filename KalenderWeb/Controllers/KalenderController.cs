using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KalenderWeb.Controllers
{
  public class KalenderController : Controller
  {
    // GET: Kalender
    public ActionResult Index()
    {
      var bytes = icalParser.ICalCreator.CreateIcal();
      var contentType = "text/calendar";
      return File(bytes, contentType, "hmvblg.ical");
    }
  }
}