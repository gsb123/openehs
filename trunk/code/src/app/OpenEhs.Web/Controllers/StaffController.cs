using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Web.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        //
        // GET: /Staff/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            return View();
        }

        public ActionResult Delete(Staff staff)
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var staff = new StaffRepository().Get(id);

            return View(staff);
        }

    }
}
