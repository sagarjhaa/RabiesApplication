using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class Bite : IActive,IModel,IAuditable
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }

        //Which city the bite occured
        [DisplayName("City")]
        public int CityId { get; set; }

        public  City City { get; set; }

        //What state the bite occured
        //It will be Ohio for us
        [DisplayName("State")]
        public int StateId { get; set; }

        public  State State { get; set; }


        [Required]
        //When bite happened
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",ApplyFormatInEditMode = true)]
        [DisplayName("Bite Date")]
        public DateTimeOffset? BiteDate { get; set; }

        [Required]
        //When it was reported to us
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",ApplyFormatInEditMode = true)]
        [DisplayName("Bite Report Date")]
        public DateTimeOffset? BiteReportDate { get; set; }

        [Required]
        //Where did we get this information from
        [DisplayName("Bite Reported By")]
        public string BiteReportedBy { get; set; }
        [DisplayName("Bite Status")]
        public int BiteStatusId { get; set; }

        public  BiteStatus BiteStatus { get; set; }

        public string Comments { get; set; }

        //public DateTimeOffset? InvestigationCompletionDate { get; set; }
        [DisplayName("Employee Assigned")]
        public string EmployeeAssignedId { get; set; }
        
        public bool Active { get; set; }
        [DisplayName("Investigation Complete Date")]
        public DateTime? InvestigationCompletionDate { get; set; }
        [DisplayName("Report Closed Date")]
        public DateTime? ReportClosedDate { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public int EmployeeCreatedId { get; set; }
        public int EmployeeEditedId { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<HumanVictim> HumanVictims { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
    }
}