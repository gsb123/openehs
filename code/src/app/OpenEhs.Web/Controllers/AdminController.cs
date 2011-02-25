using System.Web.Mvc;
using OpenEhs.Domain;
using System;
using System.Web.Security;
using OpenEhs.Data;

namespace OpenEhs.Web.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region JsonResults

        #region UserMethods

        public JsonResult AddStaffMember()
        {
            try
            {
                StaffRepository staffRepo = new StaffRepository();

                //Staff Object
                Staff staff = new Staff();
                staff.FirstName = Request.Form["FirstName"];
                if (Request.Form["MiddleName"] != "")
                    staff.MiddleName = Request.Form["MiddleName"];
                staff.LastName = Request.Form["LastName"];
                staff.PhoneNumber = Request.Form["PhoneNumber"];
                staff.StaffType = (StaffType)Enum.Parse(typeof(StaffType), Request.Form["StaffType"]);
                if (Request.Form["LicenseNumber"] != "")
                    staff.LicenseNumber = Request.Form["LicenseNumber"];
                staff.IsActive = true;

                //Address Object
                Address address = new Address();
                address.Street1 = Request.Form["Street1"];
                if (Request.Form["Street2"] != "")
                    address.Street2 = Request.Form["Street2"];
                address.City = Request.Form["City"];
                address.Region = Request.Form["Region"];
                address.Country = Request.Form["Country"];
                address.IsActive = true;
                staff.Address = address;



                //Build username
                int i = 0;
                int j = 1;
                string Username = "";
                do
                {
                    if (i < staff.FirstName.Length)
                    {
                        i++;
                        Username = staff.FirstName.Substring(0, i) + staff.LastName;
                    }
                    else
                        Username = staff.FirstName + staff.LastName + j.ToString();
                }
                while (staffRepo.UserExists(Username));

                //User Object
                User user = new User();
                user.Username = Username;
                if (Request.Form["EmailAddress"] != "")
                    user.EmailAddress = Request.Form["EmailAddress"];
                user.Password = Membership.GeneratePassword(8, 1);
                user.DateCreated = DateTime.Now;
                user.IsOnline = false;
                user.IsLockedOut = false;
                user.IsApproved = true;
                user.IsActive = true;
                staff.User = user;

                UnitOfWork.CurrentSession.Flush();

                return Json(new
                {
                    error = false,
                    username = staff.User.Username,
                    password = staff.User.Password
                });
            }
            catch
            {
                return Json(new
                {
                    error = true
                });
            }
        }

        public JsonResult RemoveStaffMember()
        {
            try
            {

                StaffRepository staffRepo = new StaffRepository();
                Staff staff = staffRepo.Get(int.Parse(Request.Form["StaffId"]));
                staff.IsActive = false;
                staff.User.IsActive = false;
                UnitOfWork.CurrentSession.Flush();

                return Json(new
                {
                    error = false,
                });
            }
            catch
            {
                return Json(new
                {
                    error = true
                });
            }
        }

        #endregion

        #region ProductMethods

        public JsonResult AddProduct()
        {
            try
            {
                CategoryRepository categoryRepo = new CategoryRepository();
                Product product = new Product();
                product.Name = Request.Form["Name"];
                product.Unit = Request.Form["Unit"];
                product.Category = categoryRepo.Get(int.Parse(Request.Form["CategoryId"]));
                product.Price = Decimal.Parse(Request.Form["Price"]);
                product.QuantityOnHand = int.Parse(Request.Form["QuantityOnHand"]);
                product.Counter = 0;
                product.IsActive = true;

                UnitOfWork.CurrentSession.Flush();

                return Json(new { 
                    error = false
                });
            }
            catch
            {
                return Json(new { 
                error = true
            });
            }
            
        }

        public JsonResult RemoveProduct()
        {
            try
            {
                ProductRepository productRepo = new ProductRepository();
                Product product = productRepo.Get(int.Parse(Request.Form["ProductId"]));
                product.IsActive = false;
                UnitOfWork.CurrentSession.Flush();

                return Json(new
                {
                    error = false
                });
            }
            catch
            {
                return Json(new
                {
                    error = true
                });
            }
        }

        #endregion

        #region LocationMethods

        public JsonResult AddLocation()
        {
            try
            {
                Location loc = new Location();

                loc.Department = Request.Form["Department"];
                loc.RoomNumber = int.Parse(Request.Form["RoomNumber"]);

                UnitOfWork.CurrentSession.Flush();

                return Json(new
                {
                    error = false
                });
            }
            catch
            {
                return Json(new
                {
                    error = true
                });
            }
        }

        #endregion

        #endregion
    }
}
