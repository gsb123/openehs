using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;
using OpenEhs.Web.Models;

namespace OpenEhs.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
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

        private static string RolesToString(IList<Role> roles)
        {
            var result = new StringBuilder();

            for(var index = 0; index < roles.Count; index++)
            {
                if (index == roles.Count - 1)
                {
                    result.Append(roles[index].Name);
                }

                result.AppendFormat("{0}, ", roles[index].Name);
            }
            
            return result.ToString();
        }
    }
}
