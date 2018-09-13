using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Reflection;

namespace DrilledHoleSurvey.Class
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

    public class DrilledHoleSurveyClass
    {
        public const string AdministratorName = "admin";
        public const string DefaultLatitude = "-31.9";
        public const string DefaultLongitude = "115.8";

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();
        }

    }
}