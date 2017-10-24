using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{
    public class StatesRepository :ActiveRepository<State>
    {
        public override IQueryable<State> All()
        {
            return base.All().Where(s => s.Active == Constant.Active).OrderBy(s => s.StateName);
        }
    }

    public class CountiesRepository : ActiveRepository<County>
    {
        public override IQueryable<County> All()
        {
            return base.All().Where(s => s.Active == Constant.Active).OrderBy(c => c.Name);
        }

        public IOrderedEnumerable<County> GetCountiesByStateId(string stateId)
        {
            if (stateId == null)
            {
                var county = new List<County>()
                {
                    new County(){
                    Id = "",
                    Name = "Select County"
                }};

                return county.OrderBy(c => c.Id);
            }


            var counties = (from c in Context.Counties
                          where c.Active == Constant.Active
                          where c.StateId.Equals(stateId)
                          select c
                );

            return counties.ToList().OrderBy(c => c.Name);

        }

    }

    public class CitiesRepository : ActiveRepository<City>
    {
        
        public override IQueryable<City> All()
        {
            return base.All().Where(c => c.Active == Constant.Active);
        }
        public IOrderedEnumerable<City> GetCitiesByState(string stateId)
        {
            if (stateId == null)
            {
                var city = new List<City>()
                {
                    new City(){
                    Id = "",
                    CityName = "Select City"
                }};

                return city.OrderBy(c => c.Id);
            }


            var cities = (from c in Context.Cities
                where c.Active == Constant.Active
                where c.StateId.Equals(stateId)
                select c
                );

            return cities.ToList().OrderBy(c => c.CityName);

        }
    }

    public class BiteStatusRepository : ActiveRepository<BiteStatus>
    {
        public override IQueryable<BiteStatus> All()
        {
            return base.All().Where(c => c.Active == Constant.Active);
        }
    }

    public class BreedRepository : ActiveRepository<Breed>
    {
        public override IQueryable<Breed> All()
        {
            return base.All().Where(b => b.Active.Equals(Constant.Active)).OrderBy(b => b.Description);
        }
    }

    public class SpeciesRepository : ActiveRepository<Species>
    {
        public override IQueryable<Species> All()
        {
            return base.All().Where(s => s.Active.Equals(Constant.Active)).OrderBy(s => s.Description);
        }

        //public List<SelectListItem> GetList()
        //{
        //    var newItem = new SelectListItem()
        //    {
        //        Text = "Select One",
        //        Value = "",
        //        Selected = true
        //    };

        //    var selectList = new SelectList(All(),"Id","Description",newItem);

        //    var Items = new List<SelectListItem>();
            


        //    return selectList;
        //}
    }

}
