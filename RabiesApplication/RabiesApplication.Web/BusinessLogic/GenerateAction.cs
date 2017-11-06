using System;
using AutoMapper;
using Action = RabiesApplication.Models.Action;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.Repositories;

namespace RabiesApplication.Web.BusinessLogic
{

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
    }

    public class ReminderHelper
    {
        private static readonly  BiteRepository _BiteRepository = new BiteRepository();


        public void OnLetterGenerated(object source, ReminderEventArgs e)
        {
            
        }

    }
}
