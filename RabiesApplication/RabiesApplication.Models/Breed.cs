using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RabiesApplication.Models;

namespace RabiesApp.Models
{
    public class Breed : IActive, IModel
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }
        [Required]
        public string Description { get; set; }
        public string EmployeecreatedId { get; set; }
        public string EmployeeeditedId { get; set; }
        public DateTimeOffset Recordcreated { get; set; }
        public DateTimeOffset? Recordedited { get; set; }
        public bool Active { get; set; }

    }
}
