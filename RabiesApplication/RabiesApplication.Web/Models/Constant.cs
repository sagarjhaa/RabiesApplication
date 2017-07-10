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

        //Todo All models with DateTimeOffset needs to show date in MM/DD/YYYY Format
        //public const string DateFormat = "{0:MM/dd/yyyy}";


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

    public static class BiteStatusConstant
    {
        public const string New = "1";
        public const string Open = "2";
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
    
}
