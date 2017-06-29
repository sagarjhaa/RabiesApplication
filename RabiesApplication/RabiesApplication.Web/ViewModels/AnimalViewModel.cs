using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RabiesApplication.Models;

namespace RabiesApplication.Web.ViewModels
{
    public class AnimalViewModel
    {
        public Animal Animal { get; set; }
        public IEnumerable<Breed> Breeds { get; set; }
        public IEnumerable<Species> Specieses { get; set; }
        public IEnumerable<Vet> Vets { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
