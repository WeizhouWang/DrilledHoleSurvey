using DrilledHoleSurvey.Class;
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
                var model = new HomeModel();
                var drilledHoleDb = new DrilledHoleDbEntities();
                model.DrilledHoleList = drilledHoleDb.Table_DrilledHole.ToList();
                model.Latitude = DrilledHoleSurveyClass.DefaultLatitude;
                model.Longitude = DrilledHoleSurveyClass.DefaultLongitude;
                return View(model);
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

        [HttpGet]
        public ActionResult EditDrilledHole(string holeName)
        {
            if (Request.IsAuthenticated)
            {
                var drilledHoleDb = new DrilledHoleDbEntities();
                var hole = drilledHoleDb.Table_DrilledHole.FirstOrDefault(a => a.HoleName == holeName);
                var model = new DrilledHoleModel()
                {
                    HoleName = hole.HoleName,
                    Latitude = hole.Latitude,
                    Longitude = hole.Longitude,
                    Dip = hole.Dip,
                    Azimuth = hole.Azimuth
                };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult EditDrilledHole(DrilledHoleModel model)
        {
            if (Request.IsAuthenticated) 
            {
                DrilledHoleDbEntities drilledHoleDb = new DrilledHoleDbEntities();
                var hole = drilledHoleDb.Table_DrilledHole.FirstOrDefault(a => a.HoleName == model.HoleName);
                hole.Latitude = model.Latitude;
                hole.Longitude = model.Longitude;
                hole.Dip = model.Dip;
                hole.Azimuth = model.Azimuth;
                drilledHoleDb.SaveChanges();
                return RedirectToAction("DrilledHoleList");
                
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult DeleteDrilledHole(string holeName)
        {
            if (Request.IsAuthenticated)
            {
                DrilledHoleDbEntities drilledHoleDb = new DrilledHoleDbEntities();
                var holeDepthList = drilledHoleDb.Table_HoleDepthInfo.Where(a => a.HoleName == holeName).ToList();
                var hole = drilledHoleDb.Table_DrilledHole.FirstOrDefault(a => a.HoleName == holeName);
                drilledHoleDb.Table_HoleDepthInfo.RemoveRange(holeDepthList);
                drilledHoleDb.Table_DrilledHole.Remove(hole);
                drilledHoleDb.SaveChanges();
                return RedirectToAction("DrilledHoleList");
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult AddDrilledHole()
        {
            if (Request.IsAuthenticated)
            {
                DrilledHoleModel model = new DrilledHoleModel();
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult AddDrilledHole(DrilledHoleModel model)
        {
            if (Request.IsAuthenticated)
            {
                DrilledHoleDbEntities drilledHoleDb = new DrilledHoleDbEntities();
                var hole = new Table_DrilledHole();
                hole.HoleName = model.HoleName;
                hole.Latitude = model.Latitude;
                hole.Longitude = model.Longitude;
                hole.Dip = model.Dip;
                hole.Azimuth = model.Azimuth;
                drilledHoleDb.Table_DrilledHole.Add(hole);
                drilledHoleDb.SaveChanges();
                return RedirectToAction("DrilledHoleList");
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion

    }
}
