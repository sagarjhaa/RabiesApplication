using System;
using Action = RabiesApplication.Models.Action;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.BusinessLogic
{
    public class GenerateAction
    {
        private Action _action;

        public Action SendLetter(string biteId,int typeofLetter)
        {
            this._action.BiteId = biteId;
            this._action.ActionType = "Letter";

            switch (typeofLetter)
            {
                case (int)Letters.TenDayQSame:
                    this._action.Comments = "Letter sent Ten Day Quarantine Owner Victim same";
                    break;

                case (int)Letters.TenDayQDifferent:
                    this._action.Comments = "Letter sent Ten Day Quarantine Owner Victim different.";
                    break;

                case (int)Letters.TenDayQShelter:
                    this._action.Comments = "Letter sent Ten Day Quarantine to shelter.";
                    break;

                case (int)Letters.FourFiveDayQ:
                    this._action.Comments = "Letter sent 45 Day Quarantine.";
                    break;

                case (int)Letters.SixMonthQ:
                    this._action.Comments = "Letter sent six months quarantine.";
                    break;

                case (int)Letters.WildUnknownAnimal:
                    this._action.Comments = "Letter sent Wild Unknown animal.";
                    break;
            }

            return _action;
        }
    }
}
