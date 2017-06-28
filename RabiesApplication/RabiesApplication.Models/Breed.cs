using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class Breed : IActive, IModel,IAuditable
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }
        [Required]
        public string Description { get; set; }
        
        public bool Active { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}
