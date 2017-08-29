using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class City :IModel, IActive, IAuditable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("City")]
        public int CityName { get; set; }
       
        public int StateId { get; set; }
        public State State { get; set; }

        public bool Active { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public int EmployeeCreatedId { get; set; }
        public int EmployeeEditedId { get; set; }
    }
}
