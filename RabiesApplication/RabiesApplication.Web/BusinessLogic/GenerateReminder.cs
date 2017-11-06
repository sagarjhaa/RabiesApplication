using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RabiesApplication.Models;
using RabiesApplication.Web.Repositories;

namespace RabiesApplication.Web.BusinessLogic
{

    public class ReminderHelper
    {
        private static readonly InvestigationRepository _investigationRepository = new InvestigationRepository();

        public void OnReminderGenerated(object source, ReminderEventArgs e)
        {
            var reminder = Mapper.Map<ReminderEventArgs, Investigation>(e);

            _investigationRepository.Insert(reminder);
            _investigationRepository.SaveChangesAsync();

        }

    }
}
