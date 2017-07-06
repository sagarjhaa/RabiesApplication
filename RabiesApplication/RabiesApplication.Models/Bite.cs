using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class Bite : IActive,IModel,IAuditable, INotifyPropertyChanged
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        //Which city the bite occured
        public string CityId { get; set; }

        public  City City { get; set; }

        //What state the bite occured
        //It will be Ohio for us
        private string stateId;

        public string StateId
        {
            get
            {
                return stateId;
            }
            set
            {
                if (Equals(stateId,value))
                {
                 return;   
                }
                stateId = value;
                OnPropertyChanged();
            }
        }

        public  State State { get; set; }


        [Required]
        //When bite happened
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",ApplyFormatInEditMode = true)]
        public DateTimeOffset? BiteDate { get; set; }

        [Required]
        //When it was reported to us
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",ApplyFormatInEditMode = true)]
        public DateTimeOffset? BiteReportDate { get; set; }

        [Required]
        //Where did we get this information from
        public string BiteReportedBy { get; set; }

        public string BiteStatusId { get; set; }

        public  BiteStatus BiteStatus { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}