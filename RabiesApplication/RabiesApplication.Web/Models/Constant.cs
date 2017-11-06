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

        public static string Success = "success";
        public static string Error = "error";

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


    public static class LettersInfo
    {
        public static int Days10 = 10;
        public static int Days45 = 45;
        public static int Months6 = 6;

        public static string SameLetterDescription = "Letter sent Ten Day Quarantine Owner Victim same.";
        public static string DifferentLetterDescription = "Letter sent Ten Day Quarantine Owner Victim different.";
        public static string ShelterLetterDescription = "Letter sent Ten Day Quarantine to shelter.";
        public static string FourFiveLetterDescription = "Letter sent 45 Day Quarantine.";
        public static string WildUnknownLetterDescription = "Letter sent Wild Unknown animal.";
        public static string SixMonthLetterDescription = "Letter sent six months quarantine.";

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
