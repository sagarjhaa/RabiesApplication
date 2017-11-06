using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            var investigationDb = _investigationRepository.Context.Investigations.FirstOrDefault(b => b.BiteId.Equals(reminder.BiteId));

            if (investigationDb != null)
            {
                reminder.Id = investigationDb.Id;
                _investigationRepository.Context.Entry(investigationDb).State = EntityState.Detached;
            }
            

            if (reminder.Id == null)
            {
                _investigationRepository.Insert(reminder);
            }
            else
            {
                _investigationRepository.Update(reminder);
            }
            _investigationRepository.SaveChangesAsync();

        }

    }
}
