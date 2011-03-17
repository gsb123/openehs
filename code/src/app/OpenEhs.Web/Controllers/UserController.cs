using System;
using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Web.Models;

namespace OpenEhs.Web.Controllers
{
    [Authorize(Roles="Administrators")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

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
            return View(new UserDetailsViewModel(_userRepository.Get(id)));
        }

        [HttpPost]
        public ActionResult Details(int id, FormCollection collection)
        {
            var user = _userRepository.Get(id);

            user.Password = collection["Password"];
            user.EmailAddress = collection["EmailAddress"];
            user.Staff.FirstName = collection["Staff.FirstName"];
            user.Staff.MiddleName = collection["Staff.MiddleName"];
            user.Staff.LastName = collection["Staff.LastName"];
            user.Staff.Address.Street1 = collection["Staff.Address.Street1"];
            user.Staff.Address.Street2 = collection["Staff.Address.Street2"];
            user.Staff.Address.City = collection["Staff.Address.City"];
            user.Staff.Address.Region = collection["Staff.Address.Region"];
            user.Staff.PhoneNumber = collection["Staff.PhoneNumber"];

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddRole(int id, int userId)
        {
            var roleToAdd = _roleRepository.Get(id);
            var user = _userRepository.Get(userId);

            try
            {
                user.AddRole(roleToAdd);
            }
            catch (ArgumentException ex)
            {
                return Json(new {success = false, error = ex.Message});
            }

            UnitOfWork.CurrentSession.Flush();

            return Json(new {success = true, RoleName = roleToAdd.Name, RoleId = roleToAdd.Id});
        }

        [HttpPost]
        public ActionResult RemoveRole(int id, int userId)
        {
            var roleToRemove = _roleRepository.Get(id);
            var user = _userRepository.Get(userId);

            user.RemoveRole(roleToRemove);

            UnitOfWork.CurrentSession.Flush();

            return Json(new {success = true});
        }

        [HttpPost]
        public ActionResult Approve(int id)
        {
            var user = _userRepository.Get(id);

            user.IsApproved = !user.IsApproved;

            return Json(new { success = true });
        }
    }
}
