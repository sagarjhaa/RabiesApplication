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
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        [Required]
        [DisplayName("Species")]
        public string Description { get; set; }

        public bool Active { get; set; }
        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}
