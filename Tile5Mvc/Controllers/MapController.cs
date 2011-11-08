using System.Web.Mvc;

namespace Tile5Mvc.Controllers
{
    public class MapController : Controller
    {
        // Display the map view
        public ActionResult Index()
        {
            return View();
        }

        // Return the requested cadastral information
        [HttpPost]
        public JsonResult RetrieveCadastre(SpatialDataAccess.Bounds bounds)
        {
            return this.Json(SpatialDataAccess.Cadastre.Retrieve(bounds));
        }
    }
}
