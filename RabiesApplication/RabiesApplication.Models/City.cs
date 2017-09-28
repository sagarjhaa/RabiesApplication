using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;
using RabiesApplication.Models.Interfaces;

namespace RabiesApplication.Models
{
    public class City :IModel, IActive, IAuditable
    {
        [Key]
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        [Required]
        [DisplayName("City")]
        public string CityName { get; set; }

        public string CountyId { get; set; }
        public County County { get; set; }
       
        public string StateId { get; set; }
        public State State { get; set; }

        public bool Active { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}
