using System;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class Action : IModel,IAuditable
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        [Required]
        public string ActionType { get; set; }
        public string BiteId { get; set; }
        public Bite Bites { get; set; }
        [Required]
        public string Comments { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}
