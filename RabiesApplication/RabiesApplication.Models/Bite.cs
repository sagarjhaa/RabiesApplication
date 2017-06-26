using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class Bite : IActive,IModel,IAuditable
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        //Which city the bite occured
        public string CityId { get; set; }

        public City City { get; set; }

        //What state the bite occured
        //It will be Ohio for us
        public string StateId { get; set; }

        public State State { get; set; }


        [Required]
        //When bite happened
        public DateTimeOffset? BiteDate { get; set; }

        [Required]
        //When it was reported to us
        public DateTimeOffset? BiteReportDate { get; set; }

        [Required]
        //Where did we get this information from
        public string BiteReportedBy { get; set; }

        public string BiteStatusId { get; set; }

        public BiteStatus BiteStatus { get; set; }

        public string Comments { get; set; }

        //public DateTimeOffset? InvestigationCompletionDate { get; set; }
        
        public string EmployeeAssignedId { get; set; }
        
        public bool Active { get; set; }

        //public virtual ICollection<Animal> Animals { get; set; }
        //public virtual ICollection<HumanVictim> HumanVictims { get; set; }
        //public virtual ICollection<Action> Actions { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}