using System;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class BiteStatus :IModel, IActive, IAuditable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Active { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public int EmployeeCreatedId { get; set; }
        public int EmployeeEditedId { get; set; }
    }
}
