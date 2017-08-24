using System;
using System.Collections.Generic;
using RabiesApplication.Models;
using Action = RabiesApplication.Models.Action;

namespace RabiesApplication.Web.ViewModels
{
    public class BiteDetailsViewModel
    {
        public Bite Bite { get; set; }
        //public IEnumerable<Employee> Employees { get; set; }

        #region HumanVictim

        public IEnumerable<HumanVictim> HumanVictims { get; set; }
        #endregion

        #region Pet
        public IEnumerable<Animal> Pets { get; set; }
        public Animal Animal { get; set; }

        #endregion

        public PetOwner PetOwner { get; set; }

        public IEnumerable<Action> Actions { get; set; }
    }
}
