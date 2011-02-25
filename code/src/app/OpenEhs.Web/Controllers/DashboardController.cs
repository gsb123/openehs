using System.Web.Mvc;
using OpenEhs.Web.Models;

namespace OpenEhs.Web.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            var viewModel = new DashboardViewModel();

            return View(viewModel);
        }

    }
}
