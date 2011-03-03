using System;
using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Web.Models;

namespace OpenEhs.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();
        }

        public ActionResult Index(int? page)
        {
            var pageIndex = page ?? 1;
            var users = _userRepository.GetPaged(pageIndex, 10);

            return View(new UserViewModel(users));
        }

        public ActionResult Details(int id)
        {
            ViewBag.CurrentUserId = id;
            return View(new UserDetailsViewModel(_userRepository.Get(id)));
        }

        [HttpPost]
        public ActionResult AddRole(int id)
        {
            var roleToAdd = _roleRepository.Get(id);
            var user = _userRepository.Get(Convert.ToInt32(ViewBag.CurrentUserId));

            try
            {
                user.AddRole(roleToAdd);
            }
            catch (ArgumentException ex)
            {
                return Json(new {success = false, error = ex.Message});
            }

            return Json(new {success = true});
        }

        [HttpPost]
        public ActionResult RemoveRole(int id)
        {
            var roleToRemove = _roleRepository.Get(id);
            var user = _userRepository.Get(Convert.ToInt32(ViewBag.CurrentUserId));

            user.RemoveRole(roleToRemove);

            return Json(new {success = true});
        }
    }
}
