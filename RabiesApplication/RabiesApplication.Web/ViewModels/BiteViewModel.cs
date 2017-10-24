using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;

namespace RabiesApplication.Web.ViewModels
{
    public class BiteViewModel
    {
        public Bite Bite { get; set; }

        public IEnumerable<State> States { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public Dictionary<string,string> Employees { get; set; }

        public IEnumerable<BiteStatus> BiteStatuses { get; set; }
    }
}
