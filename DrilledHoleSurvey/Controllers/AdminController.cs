using DrilledHoleSurvey.Models;
using System.Linq;
using System.Web.Mvc;

namespace DrilledHoleSurvey.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Home(string status)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("DrilledHoleList");
            }
            return RedirectToAction("Login", "Account");
        }

        #region Drilled Hole
        [HttpGet]
        public ActionResult DrilledHoleList()
        {
            if (Request.IsAuthenticated)
            {
                DrilledHoleDbEntities drilledHolesDb = new DrilledHoleDbEntities();
                DrilledHoleListModel model = new DrilledHoleListModel();
                model.DrilledHoleList = drilledHolesDb.Table_DrilledHole.ToList();
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion

    }
}
