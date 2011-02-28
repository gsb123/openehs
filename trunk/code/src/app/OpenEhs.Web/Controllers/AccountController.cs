using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using OpenEhs.Data;
using OpenEhs.Domain;
using OpenEhs.Web.Models;

namespace OpenEhs.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        private IStaffRepository _staffRepository;
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        public AccountController()
        {
            _userRepository = new UserRepository();
            _staffRepository = new StaffRepository();
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, false);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Dashboard");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.Username, model.Password,
                                                                                   model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    var staff = new Staff
                                    {
                                        FirstName = model.FirstName,
                                        MiddleName = model.MiddleName,
                                        LastName = model.LastName,
                                        StaffType = model.Title,
                                        LicenseNumber = model.LicenseNumber,
                                        PhoneNumber = model.PhoneNumber,
                                        Address = new Address
                                                      {
                                                          Street1 = model.Street1,
                                                          Street2 = model.Street2,
                                                          City = model.City,
                                                          Region = model.Region,
                                                          Country = model.Country,
                                                          IsActive = true
                                                      },
                                        User = new User
                                                   {
                                                       Username = model.Username,
                                                       Password = model.Password,
                                                       EmailAddress = model.Email,
                                                       LastActivity = DateTime.Now,
                                                       LastLogin = DateTime.Now,
                                                       DateCreated = DateTime.Now,
                                                       PasswordQuestion = String.Empty,
                                                       PasswordAnswer = String.Empty,
                                                       LastPasswordChange = DateTime.MinValue,
                                                       LastLockout = DateTime.MinValue,
                                                       ApplicationName = "/",
                                                       IpAddress = Request.ServerVariables["REMOTE_ADDR"],
                                                       IsActive = true,
                                                       IsApproved = false,
                                                       IsLockedOut = false,
                                                       IsOnline = true,
                                                       FailedPasswordAttemptCount = 0
                                                   }
                                    };


                    _staffRepository.Add(staff);

                    FormsService.SignIn(staff.User.Username, false);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;

            return View(model);
        }

        public JsonResult CheckForUsernameAvailability(string username)
        {
            username = username.ToLower();
            var isAvailable = _userRepository.CheckForUsernameAvailability(username);
            return Json(new {requestedUsername = username});
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}
