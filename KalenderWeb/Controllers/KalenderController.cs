using System.Web.Mvc;

namespace KalenderWeb.Controllers
{
  public class KalenderController : Controller
  {
    // GET: Kalender
    public ActionResult Index()
    {
      var bytes = ICalCreator.ICalCreator.CreateIcal();
      var contentType = "text/calendar";
      return File(bytes, contentType, "hmvblg.ical");
    }
  }
}