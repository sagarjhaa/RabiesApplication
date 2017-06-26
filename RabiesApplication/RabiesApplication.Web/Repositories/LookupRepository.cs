using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;

namespace RabiesApplication.Web.Repositories
{
    public class StatesRepository :BaseRepository<State>
    {
        public override Task<State> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override Task InsertOrUpdateAsync(State model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<State> GetAllStates()
        {
            return Context.States.AsQueryable();
        }
    }
}
