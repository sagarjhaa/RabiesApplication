using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Repositories;

namespace RabiesApplication.Web.ViewModels
{
    public class BiteViewModel
    {
        public Bite Bite { get; set; }

        public IEnumerable<State> States { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public IEnumerable<BiteStatus> BiteStatuses { get; set; }



        //public ActionRepository ActionRepository = new ActionRepository();

        //public BiteViewModel()
        //{
        //    Bite = new Bite();
        //    Bite.PropertyChanged += ActionRepository.OnPropertyChanged;
        //}
    }
}
