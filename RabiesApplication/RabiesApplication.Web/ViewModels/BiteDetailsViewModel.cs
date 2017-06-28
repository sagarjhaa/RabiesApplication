﻿using System;
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
        public IEnumerable<HumanVictim> HumanVictims { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<County> Counties { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}