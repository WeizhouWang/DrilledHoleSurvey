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

        #region HoleDepthInfo
        [HttpGet]
        public ActionResult HoleDepthInfoList(string holeName)
        {
            if (Request.IsAuthenticated)
            {
                var drilledHoleDb = new DrilledHoleDbEntities();
                var drilledHole = drilledHoleDb.Table_DrilledHole.FirstOrDefault(a => a.HoleName == holeName);
                var holeDepthInfoList = drilledHoleDb.View_HoleDepthInfo.Where(a => a.HoleName == holeName).OrderBy(a=>a.Depth).ToList();
                DrilledHoleSurveyClass.CheckAzimuthValue(drilledHole.Azimuth, holeDepthInfoList);
                DrilledHoleSurveyClass.CheckDipValue(drilledHole.Dip, holeDepthInfoList);
                var model = new HoleDepthInfoListModel()
                {
                    HoleName = holeName,
                    HoleDepthInfoList = holeDepthInfoList
                };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public ActionResult EditHoleDepthInfo(string holeName, int depth)
        {
            if (Request.IsAuthenticated)
            {
                var drilledHoleDb = new DrilledHoleDbEntities();
                var depthInfo = drilledHoleDb.Table_HoleDepthInfo.FirstOrDefault(a => a.HoleName == holeName && a.Depth == depth);
                var model = new HoleDepthInfoModel()
                {
                    HoleName = depthInfo.HoleName,
                    Depth = depthInfo.Depth,
                    Dip = depthInfo.Dip,
                    Azimuth = depthInfo.Azimuth
                };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult EditHoleDepthInfo(HoleDepthInfoModel model)
        {
            if (Request.IsAuthenticated)
            {
                DrilledHoleDbEntities drilledHoleDb = new DrilledHoleDbEntities();
                var depthInfo = drilledHoleDb.Table_HoleDepthInfo.FirstOrDefault(a => a.HoleName == model.HoleName && a.Depth == model.Depth);
                depthInfo.Dip = model.Dip;
                depthInfo.Azimuth = model.Azimuth;
                drilledHoleDb.SaveChanges();
                return RedirectToAction("HoleDepthInfoList", new { holeName = model.HoleName });

            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult DeleteHoleDepthInfo(string holeName, double depth)
        {
            if (Request.IsAuthenticated)
            {
                DrilledHoleDbEntities drilledHoleDb = new DrilledHoleDbEntities();
                var depthInfo = drilledHoleDb.Table_HoleDepthInfo.FirstOrDefault(a => a.HoleName == holeName && a.Depth == depth);
                drilledHoleDb.Table_HoleDepthInfo.Remove(depthInfo);
                drilledHoleDb.SaveChanges();
                return RedirectToAction("HoleDepthInfoList", new { holeName = holeName });
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult AddHoleDepthInfo(string holeName)
        {
            if (Request.IsAuthenticated)
            {
                HoleDepthInfoModel model = new HoleDepthInfoModel();
                model.HoleName = holeName;
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult AddHoleDepthInfo(HoleDepthInfoModel model)
        {
            if (Request.IsAuthenticated)
            {
                DrilledHoleDbEntities drilledHoleDb = new DrilledHoleDbEntities();
                var depthInfo = new Table_HoleDepthInfo();
                depthInfo.HoleName = model.HoleName;
                depthInfo.Depth = model.Depth;
                depthInfo.Dip = model.Dip;
                depthInfo.Azimuth = model.Azimuth;
                drilledHoleDb.Table_HoleDepthInfo.Add(depthInfo);
                drilledHoleDb.SaveChanges();
                return RedirectToAction("HoleDepthInfoList", new { holeName = model.HoleName });
            }
            return RedirectToAction("Login", "Account");
        }
        #endregion
    }
}
