using DrilledHoleSurvey.Class;
using DrilledHoleSurvey.Filters;
using DrilledHoleSurvey.Models;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Linq;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace DrilledHoleSurvey.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            UserProfileContext userprofile_db = new UserProfileContext();
            UserProfile user = userprofile_db.UserProfiles_DbSet.FirstOrDefault(a => a.UserName == DrilledHoleSurveyClass.AdministratorName);
            if (user == null)
            {
                WebSecurity.CreateUserAndAccount(DrilledHoleSurveyClass.AdministratorName, "111111");
            }
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DrilledHoleDbEntities drilledHoles_db = new DrilledHoleDbEntities();
                    if (WebSecurity.Login(model.UserName, model.Password))
                    {
                        if (model.UserName == DrilledHoleSurveyClass.AdministratorName)
                        {
                            return RedirectToAction("Home", "Admin");
                        }

                    }
                    ModelState.AddModelError("", "Username or password provided is incorrect.");
                    return View(model);
                }
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            try
            {
                WebSecurity.Logout();
                return RedirectToAction("Login", "Account");
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
