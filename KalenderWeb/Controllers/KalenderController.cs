using System.Web.Mvc;

namespace KalenderWeb.Controllers
{
  public class KalenderController : Controller
  {
    // GET: Kalender
    [OutputCache(Duration = 0)]
    public ActionResult Index()
    {
      var bytes = ICalCreator.ICalCreator.CreateIcal();
      var contentType = "text/calendar";
      return File(bytes, contentType, "hmvmkblg.ical");
    }
  }
}