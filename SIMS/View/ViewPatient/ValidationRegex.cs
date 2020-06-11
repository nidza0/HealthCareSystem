using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewPatient
{
    class ValidationRegex
    {

        public static string GetPhoneNumberRegex()
        {
            //return @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            //return "/^[0-9()-]+$/";
            //return @"/^[0-9()-]+$/";
            //return @"\b[0-9/-]{5,}\b";
            return @"^\b[0-9\.\-\/]+\b$";
        }

        public static string GetUserNameRegex()
        {
            return @".{4,}";
        }

        public static string GetPasswordRegex()
        {
            return @".{8,}";
        }

        public static string GetNameRegex()
        {
            return @"\b[A-Z a-z\.]{4,}\b";
            //return @"[A-Za-z]+[\s][A-Za-z]+[.][A-Za-z]+";
        }

        public static string GetAddressRegex()
        {
            return @"\b.{4,}\b";
        }

        public static string GetUIDNRegex()
        {
            return @"\b[0-9]{5,}\b";
        }

        public static string GetEmailRegex()
        {
            return @"^\b([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)\b$";
        }
    }
}
