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
            return @"[0-9\-]{4,}";
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
            return @"[A-Z a-z\.]{4,}";
            //return @"[A-Za-z]+[\s][A-Za-z]+[.][A-Za-z]+";
        }

        public static string GetAddressRegex()
        {
            return @".{4,}";
        }

        public static string GetUIDNRegex()
        {
            return @"[0-9]{5,}";
        }

        public static string GetEmailRegex()
        {
            return @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        }
    }
}
