using System;
using System.ComponentModel;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class County:IModel,IActive,IAuditable
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }
        [DisplayName("County")]
        public string Name { get; set; }

        public int Fips { get; set; }
        public bool Active { get; set; }


        public string StateId { get; set; }

        public State State { get; set; }
        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}
