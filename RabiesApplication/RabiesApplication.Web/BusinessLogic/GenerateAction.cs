using System;
using Action = RabiesApplication.Models.Action;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.BusinessLogic
{
    public static class GenerateAction
    {
        
        public static Action SendLetter(string biteId,int typeofLetter)
        {
            Action _action = new Action
            {
                BiteId = biteId,
                ActionType = "Letter"
            };

            switch (typeofLetter)
            {
                case (int)Letters.TenDayQSame:
                    _action.Comments = "Letter sent Ten Day Quarantine Owner Victim same";
                    break;

                case (int)Letters.TenDayQDifferent:
                    _action.Comments = "Letter sent Ten Day Quarantine Owner Victim different.";
                    break;

                case (int)Letters.TenDayQShelter:
                    _action.Comments = "Letter sent Ten Day Quarantine to shelter.";
                    break;

                case (int)Letters.FourFiveDayQ:
                    _action.Comments = "Letter sent 45 Day Quarantine.";
                    break;

                case (int)Letters.SixMonthQ:
                    _action.Comments = "Letter sent six months quarantine.";
                    break;

                case (int)Letters.WildUnknownAnimal:
                    _action.Comments = "Letter sent Wild Unknown animal.";
                    break;
            }

            return _action;
        }
    }
}
