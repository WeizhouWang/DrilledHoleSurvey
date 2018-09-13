using System;
using System.ComponentModel;
using System.Reflection;

namespace DrilledHoleSurvey.Class
{
    public class DrilledHoleSurveyClass
    {
        public const string AdministratorName = "admin";
        public const string DefaultLatitude = "-32.04";
        public const string DefaultLongitude = "115.7";

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