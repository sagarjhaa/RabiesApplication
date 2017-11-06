using System;
using AutoMapper;
using RabiesApplication.Models;
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
            _actionRepository.SaveChangesAsync();
        }
    }

}
