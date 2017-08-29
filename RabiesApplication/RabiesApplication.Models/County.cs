using System;
using System.ComponentModel;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class County:IModel,IActive,IAuditable
    {
        public int Id { get; set; }
        [DisplayName("County")]
        public string Name { get; set; }

        public int Fips { get; set; }
        public bool Active { get; set; }


        public int StateId { get; set; }

        public State State { get; set; }
        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public int EmployeeCreatedId { get; set; }
        public int EmployeeEditedId { get; set; }
    }
}
