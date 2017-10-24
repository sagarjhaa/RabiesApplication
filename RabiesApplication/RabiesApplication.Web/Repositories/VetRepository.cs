using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Repositories
{
    public class VetRepository: ActiveRepository<Vet>
    {
        public override IQueryable<Vet> All()
        {
            return base.All().Where(v => v.Active.Equals(Constant.Active)).OrderBy(v => v.FirstName);
        }

        public VetViewModel GetVetDetails(string animalId)
        {
            var vet = (from a in Context.Animals
                where a.Id.Equals(animalId)
                join v in Context.Vets on a.VetId equals v.Id
                join c in Context.Cities on v.CityId equals c.Id
                select new VetViewModel()
                {
                    Address = v.Addressline1 + " " + v.Addressline2,
                    Id = v.Id,
                    Name = v.FirstName + " " + v.LastName,
                    City = c.CityName,
                    Phone1 = v.Contactnumber1,
                    Phone2 = v.Contactnumber2,
                    Zip = v.Zipcode.ToString()
                }).FirstOrDefault();


            return vet;
        }
    }
}
