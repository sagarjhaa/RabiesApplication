using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabiesApplication.Web.Models
{
    public static class Constant
    {
        public const bool Active = true;
        public const bool Deactive = false;

        public const string OrganizationCcbh = "1";
        public const string DateFormat = "{0:MM-dd-yyy}";
        public const string DateHourFormat = "{0:MM-dd-yyy hh:mm:ss}";

        #region HELPER

        public enum ManageMessageId
        {
            SavedBiteDataSuccess,
            SaveHumanVictimDataSuccess,
            DeleteHumanVictimSuccess,
            ErrorHumanVictimData,
            SavePetVictimDataSuccess,
            DeletePetVictimSuccess
        }

        #endregion
    }

    public enum Letters
    {
        TenDayQSame = 1,
        TenDayQDifferent,
        TenDayQShelter,
        FourFiveDayQ,
        WildUnknownAnimal,
        SixMonthQ
    }


    public static class ActionTypes
    {
        public static string Letter = "Letter";
        public static string Phone = "Phone";
        public static string Visit = "Visit";
        public static string Email = "Email";
        public static string Fax = "Fax";
    }

    public enum LettersDays
    {
        TenDayQSame = 10,
        TenDayQDifferent =10,
        TenDayQShelter = 10,
        FourFiveDayQ = 45,
        WildUnknownAnimal = 0,
        SixMonthQ = 6
    }


}
