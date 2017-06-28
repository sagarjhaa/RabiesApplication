using System;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class Action : IModel
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        [Required]
        public string ActionType { get; set; }
        public string BiteId { get; set; }
        public Bite Bites { get; set; }
        [Required]
        public string Comments { get; set; }

        public string EmployeecreatedId { get; set; }
        public string EmployeeeditedId { get; set; }
        public DateTimeOffset Recordcreated { get; set; }
        public DateTimeOffset? Recordedited { get; set; }
    }
}
