using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DrilledHoleSurvey.Models
{
    #region Home
    public class HomeModel
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public List<Table_DrilledHole> DrilledHoleList { get; set; }
        public HomeModel()
        {
            DrilledHoleList = new List<Table_DrilledHole>();
        }
    }
    #endregion

    #region DrilledHole
    public class DrilledHoleModel
    {
        [Display(Name = "Hole Name:")]
        public string HoleName { get; set; }

        [Display(Name = "Latitude:")]
        public string Latitude { get; set; }

        [Display(Name = "Longitude:")]
        public string Longitude { get; set; }

        [Display(Name = "Dip:")]
        public double Dip { get; set; }

        [Display(Name = "Azimuth:")]
        public double Azimuth { get; set; }

    }

    public class DrilledHoleListModel
    {
        public List<Table_DrilledHole> DrilledHoleList { get; set; }
        public DrilledHoleListModel()
        {
            DrilledHoleList = new List<Table_DrilledHole>();
        }
    }
    #endregion

    #region HoleDepthInfo
    public class HoleDepthInfoModel
    {
        [Display(Name = "Hole Name:")]
        public string HoleName { get; set; }

        [Display(Name = "Depth:")]
        public double Depth { get; set; }

        [Display(Name = "Dip:")]
        public double Dip { get; set; }

        [Display(Name = "Azimuth:")]
        public double Azimuth { get; set; }

    }

    public class HoleDepthInfoListModel
    {
        public string HoleName { get; set; }
        public List<View_HoleDepthInfo> HoleDepthInfoList { get; set; }
        public HoleDepthInfoListModel()
        {
            HoleDepthInfoList = new List<View_HoleDepthInfo>();
        }
    }
    #endregion

}