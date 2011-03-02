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

        public ActionResult Index()
        {
            var users = _userRepository.GetAll();

            return View(new UserViewModel(users));
        }

        public ActionResult GetUsersStartingWith(string id)
        {
            switch (id.ToUpper())
            {
                case "A":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "B":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "C":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "D":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "E":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "F":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "G":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "H":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "I":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "J":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "K":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "L":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "M":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "N":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "O":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "P":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "Q":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "R":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "S":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "T":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "U":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "V":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "W":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "X":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "Y":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                case "Z":
                    return Content(TransformUserListToTable(_userRepository.GetByLastNameInitial(id)));
                default:
                    return Content("Oops! Couldn't load the page.");
            }
        }

        private string TransformUserListToTable(IList<User> users)
        {
            var result = new StringBuilder();

            result.Append("<table>");
            result.Append("    <thead>");
            result.Append("        <tr>");
            result.Append("            <th class=\"usernameColumn\">Username</th>");
            result.Append("            <th class=\"nameColumn\">Name</th>");
            result.Append("            <th class=\"rolesColumn\">Roles</th>");
            result.Append("            <th class=\"approvedColumn\">Approved</th>");
            result.Append("        </tr>");
            result.Append("    </thead>");
            result.Append("    <tbody>");

            foreach (var user in users)
            {
                result.Append("        <tr>");
                result.AppendFormat("            <td class=\"usernameColumn\">{0}</td>", user.Username);
                result.AppendFormat("            <td class=\"nameColumn\">{1}, {0}</td>", user.Staff.FirstName, user.Staff.LastName);
                result.AppendFormat("            <td class=\"rolesColumn\">{0}</td>", RolesToString(user.Roles));
                if (user.IsApproved)
                {
                    result.AppendFormat(
                        "            <td class=\"approvedColumn\"><input type=\"checkbox\" name=\"IsApproved_{0}\" id=\"IsApproved_{0}\" checked /></td>", user.Id);
                }
                else
                {
                    result.AppendFormat(
                        "            <td class=\"approvedColumn\"><input type=\"checkbox\" name=\"IsApproved_{0}\" id=\"IsApproved_{0}\" /></td>", user.Id);
                }
                result.Append("        </tr>");
            }

            result.Append("    </tbody");
            result.Append("</table>");

            return result.ToString();
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
