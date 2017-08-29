using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class Species: IActive,IModel,IAuditable
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Species")]
        public string Description { get; set; }

        public bool Active { get; set; }
        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public int EmployeeCreatedId { get; set; }
        public int EmployeeEditedId { get; set; }
    }
}
