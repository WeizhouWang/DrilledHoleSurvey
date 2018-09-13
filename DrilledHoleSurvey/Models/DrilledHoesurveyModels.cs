using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DrilledHoleSurvey.Models
{
    #region userprofile
    public class UserProfileContext : DbContext
    {
        public UserProfileContext()
            : base("SurveyUserProfileConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles_DbSet { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
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
        public float Dip { get; set; }

        [Display(Name = "Azimuth:")]
        public float Azimuth { get; set; }

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

    #region DrilledHole
    public class HoleDetailModel
    {
        [Display(Name = "Hole Name:")]
        public string HoleName { get; set; }

        [Display(Name = "Depth:")]
        public float Depth { get; set; }

        [Display(Name = "Dip:")]
        public float Dip { get; set; }

        [Display(Name = "Azimuth:")]
        public float Azimuth { get; set; }

    }

    public class HoleDetailListModel
    {
        public List<Table_HoleDetail> HoleDetailList { get; set; }
        public HoleDetailListModel()
        {
            HoleDetailList = new List<Table_HoleDetail>();
        }
    }
    #endregion

}