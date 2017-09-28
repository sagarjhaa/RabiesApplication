using System;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;
using RabiesApplication.Models.Interfaces;

namespace RabiesApplication.Models
{
    public class Action : IModel,IActive,IAuditable
    {
        public string Id { get; set; }
        

        [Required]
        public string ActionType { get; set; }
        public string BiteId { get; set; }
        public Bite Bites { get; set; }
        [Required]
        public string Comments { get; set; }

        public string DocumentId { get; set; }
        public bool Active { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
        
    }
}
