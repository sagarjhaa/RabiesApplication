using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.BusinessLogic
{
    public class GenerateLetter
    {
        public void GenerateSendLetterAction(string biteId,string animalId, int typeofLetter)
        {
            switch (typeofLetter)
            {
                case (int)Letters.TenDayQSame:
                    var same = new TenDayQuarantineLetterSame(biteId);
                    same.LetterGenerated += new ActionsHelper().OnLetterGenerated;
                    same.ReminderGenerated += new ReminderHelper().OnReminderGenerated;
                    same.CreateLetter();
                    break;

                case (int)Letters.TenDayQDifferent:
                    var different = new TenDayQuarantineLetterDifferent(biteId);
                    different.LetterGenerated += new ActionsHelper().OnLetterGenerated;
                    different.ReminderGenerated += new ReminderHelper().OnReminderGenerated;
                    different.CreateLetter();
                    break;

                case (int)Letters.TenDayQShelter:
                    var shelter = new TenDayQuarantineShelter(biteId);
                    shelter.LetterGenerated += new ActionsHelper().OnLetterGenerated;
                    shelter.CreateLetter();
                    //_action.Comments = "Letter sent Ten Day Quarantine to shelter.";
                    break;

                case (int)Letters.FourFiveDayQ:
                    var wildAnimal1 = new FourFiveDayQuarantine(biteId);
                    wildAnimal1.LetterGenerated += new ActionsHelper().OnLetterGenerated;
                    wildAnimal1.CreateLetter();
                    //_action.Comments = "Letter sent 45 Day Quarantine.";
                    break;

                case (int)Letters.SixMonthQ:
                    var wildAnimal2 = new SixMonthQuarantine(biteId);
                    wildAnimal2.LetterGenerated += new ActionsHelper().OnLetterGenerated;
                    wildAnimal2.CreateLetter();
                    //_action.Comments = "Letter sent six months quarantine.";
                    break;

                case (int)Letters.WildUnknownAnimal:
                    var wildAnimal3 = new WildUnknowAnimal(biteId);
                    wildAnimal3.LetterGenerated += new ActionsHelper().OnLetterGenerated;
                    wildAnimal3.CreateLetter();
                    //_action.Comments = "Letter sent Wild Unknown animal.";
                    break;
            }
        }
    }
}