using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;
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

        public VetViewModel Vet { get; set; }

        public IEnumerable<ActionListViewModel> Actions { get; set; }
    }


    public class BiteJustViewModel
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        [DisplayFormat(DataFormatString = Constant.DateFormat,ApplyFormatInEditMode = true)]
        public DateTimeOffset BiteDate { get; set; }

        [DisplayFormat(DataFormatString = Constant.DateFormat,ApplyFormatInEditMode = true)]
        public DateTimeOffset ReportDate { get; set; }
        public string Comments { get; set; }
    }

    public class HumanVictimViewModel
    {
        public string Id { get; set; }
        public string BiteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

    }

    public class AnimalViewModel
    {
        public string Id { get; set; }
        public string BiteId { get; set; }
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

    public class VetViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }


    }

    public class AnimalListViewModel
    {
        public string BiteId { get; set; }
        public string AnimalId { get; set; }
    }


    public class ActionListViewModel
    {
        public string Id { get; set; }
        public string BiteId { get; set; }
        public string ActionType { get; set; }
        public string Comments { get; set; }
        public string DocumentId { get; set; }

        [DisplayFormat(DataFormatString = Constant.DateHourFormat,ApplyFormatInEditMode = true)]
        public DateTimeOffset RecordCreated { get; set; }
    }

}
