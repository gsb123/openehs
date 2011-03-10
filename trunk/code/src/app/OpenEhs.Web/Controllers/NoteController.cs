using System.Web.Mvc;
using OpenEhs.Domain;

namespace OpenEhs.Web.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        //
        // GET: /Note/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
