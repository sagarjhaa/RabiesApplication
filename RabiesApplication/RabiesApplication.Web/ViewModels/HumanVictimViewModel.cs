using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApp.Models;
using RabiesApplication.Models;

namespace RabiesApplication.Web.ViewModels
{
    public class HumanVictimViewModel
    {
        public HumanVictim HumanVictim { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public IEnumerable<County> Counties { get; set; }

        public IEnumerable<State> States { get; set; }


    }
}
