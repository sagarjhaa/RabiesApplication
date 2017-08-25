using System;
using Action = RabiesApplication.Models.Action;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.Repositories;

namespace RabiesApplication.Web.BusinessLogic
{

    public static class ActionTypes
    {
        public static string Letter = "Letter";
        public static string Phone = "Phone";
        public static string Visit = "Visit";
        public static string Email = "Email";
        public static string Fax = "Fax";
    }


    public static class ActionsHelper
    {
        private static readonly ActionRepository _actionRepository = new ActionRepository();
        private static readonly BiteRepository _biteRepository = new BiteRepository();

        public static Action GenerateSendLetterAction(string biteId,int typeofLetter)
        {
            var bite = _biteRepository.GetById(biteId).Result;

            Action _action = new Action
            {
                BiteId = biteId,
                ActionType = ActionTypes.Letter
            };

            switch (typeofLetter)
            {
                case (int)Letters.TenDayQSame:
                    _action.DocumentId =  new TenDayQuarantineLetterSame(bite).CreateLetter();
                    _action.Comments = "Letter sent Ten Day Quarantine Owner Victim same";
                    break;

                case (int)Letters.TenDayQDifferent:
                    _action.DocumentId = new TenDayQuarantineLetterDifferent(bite).CreateLetter();
                    _action.Comments = "Letter sent Ten Day Quarantine Owner Victim different.";
                    break;

                case (int)Letters.TenDayQShelter:
                    _action.DocumentId = new TenDayQuarantineShelter(bite).CreateLetter();
                    _action.Comments = "Letter sent Ten Day Quarantine to shelter.";
                    break;

                case (int)Letters.FourFiveDayQ:
                    _action.DocumentId = new FourFiveDayQuarantine(bite).CreateLetter();
                    _action.Comments = "Letter sent 45 Day Quarantine.";
                    break;

                case (int)Letters.SixMonthQ:
                    _action.DocumentId = new SixMonthQuarantine(bite).CreateLetter();
                    _action.Comments = "Letter sent six months quarantine.";
                    break;

                case (int)Letters.WildUnknownAnimal:
                    _action.DocumentId = new WildUnknowAnimal(bite).CreateLetter();
                    _action.Comments = "Letter sent Wild Unknown animal.";
                    break;
            }

            return _action;
        }

        public static void SaveActions(Action action)
        {
            if (action.Id == null)
            {
                _actionRepository.Insert(action);
            }
            else
            {
                _actionRepository.Update(action);
            }
            
            _actionRepository.SaveChangesAsync();
        }
    }
}
