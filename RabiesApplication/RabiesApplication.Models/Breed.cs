using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class Breed : IActive, IModel,IAuditable
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Breed")]
        public string Description { get; set; }
        
        public bool Active { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public int EmployeeCreatedId { get; set; }
        public int EmployeeEditedId { get; set; }
    }
}
