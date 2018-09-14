using System;
using System.Collections.Generic;
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
        public const string DipError = "Red";
        public const string AzimuthError = "Orange";

        public static bool CheckAzimuthValue(double startValue, List<View_HoleDepthInfo> holeDepthInfoList)
        {
            double compareValue = startValue;
            foreach(var depthInfo in holeDepthInfoList)
            {
                if (Math.Abs(compareValue - depthInfo.Azimuth) > 5) depthInfo.AzimuthStatus = "false";
                compareValue = depthInfo.Azimuth;
            }
            return true;
        }

        public static bool CheckDipValue(double startValue, List<View_HoleDepthInfo> holeDepthInfoList)
        {
            double value1, value2, value3, value4, value5;
            value1 = value2 = value3 = value4 = value5 = startValue;
            foreach(var depthInfo in holeDepthInfoList)
            {
                double averageValue = (value1 + value2 + value3 + value4 + value5) / 5;
                if (Math.Abs(depthInfo.Dip - averageValue) > 3) depthInfo.DipStatus = "false";
                value1 = value2;
                value2 = value3;
                value3 = value4;
                value4 = value5;
                value5 = depthInfo.Dip;
            }
            return true;
        }

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