using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabiesApplication.Models;
using RabiesApplication.Web.Repositories;
using Action = RabiesApplication.Models.Action;

namespace RabiesApplication.Web.ViewModels
{
    public class BiteDetailsViewModel
    {
        
        public BiteJustViewModel Bite { get; set; }
        public IEnumerable<HumanVictimViewModel> HumanVictims { get; set; }
        public AnimalViewModel Animal { get; set; }
        public AnimalOwnerViewModel AnimalOwner { get; set; }
    }


    public class BiteJustViewModel
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public DateTimeOffset BiteDate { get; set; }
        public DateTimeOffset ReportDate { get; set; }
        public string Comments { get; set; }
    }

    public class HumanVictimViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

    }

    public class AnimalViewModel
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Species { get; set; }
    }

    public class AnimalOwnerViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }


}
