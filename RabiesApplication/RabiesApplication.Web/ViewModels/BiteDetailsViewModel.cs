using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;

namespace RabiesApplication.Web.ViewModels
{
    public class BiteDetailsViewModel
    {
        public Bite Bite { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        #region HumanVictim

        public IEnumerable<HumanVictim> HumanVictims { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<County> Counties { get; set; }
        public IEnumerable<City> Cities { get; set; }
        

        #endregion

        #region Pet

        public IEnumerable<Animal> Animal { get; set; }
        public IEnumerable<Breed> Breeds { get; set; }
        public IEnumerable<Species> Specieses { get; set; }
        public IEnumerable<Vet> Vets { get; set; }

        #endregion

    }
}
