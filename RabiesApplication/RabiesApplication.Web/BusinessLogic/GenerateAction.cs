using System;
using AutoMapper;
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


    public class ActionsHelper
    {
        private static readonly ActionRepository _actionRepository = new ActionRepository();


        public void OnLetterGenerated(object source, ActionEventArgs e)
        {

            var action = Mapper.Map<ActionEventArgs, Action>(e);

            _actionRepository.Insert(action);
            try
            {
                _actionRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw;
            }


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
