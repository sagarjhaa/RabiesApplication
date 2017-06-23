using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApp.Models
{
    public class Bite : IActive,IModel,IAuditable
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        //Which city the bite occured
        public int CityId { get; set; }

        public City City { get; set; }

        //What state the bite occured
        //It will be Ohio for us
        public int StateId { get; set; }

        public State State { get; set; }


        [Required]
        //When bite happened
        public DateTimeOffset BiteDate { get; set; }

        [Required]
        //When it was reported to us
        public DateTimeOffset BiteReportDate { get; set; }

        [Required]
        //Where did we get this information from
        public string BiteReportedBy { get; set; }

      

        public int BiteStatusId { get; set; }

        public BiteStatus BiteStatus { get; set; }

        public string Comments { get; set; }


        //public DateTimeOffset? InvestigationCompletionDate { get; set; }
        
        public string EmployeeAssignedId { get; set; }
        
        public bool Active { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateEdited { get; set; }
        public string MemberCreatedId { get; set; }
        public string MemberEditedId { get; set; }


        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<HumanVictim> HumanVictims { get; set; }
        public virtual ICollection<Action> Actions { get; set; }

    }
}