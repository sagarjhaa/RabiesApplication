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
    public class PetOwner: IModel,IPerson,IAuditable
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        public string AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        public Animal Animal { get; set; }

        [DisplayName("Shelter?")]
        public bool IsShelter { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public DateTimeOffset? Dateofbirth { get; set; }
        public int? Age { get; set; }

        [DisplayName("Address line 1")]
        public string Addressline1 { get; set; }

        [DisplayName("Address line 2")]
        public string Addressline2 { get; set; }

        [DisplayName("City")]
        public string CityId { get; set; }

        public City City { get; set; }

        public string CountyId { get; set; }

        [DisplayName("State")]
        public string StateId { get; set; }

        public State State { get; set; }

        [Required]
        public int? Zipcode { get; set; }

        [DisplayName("Primary Contact")]
        public string Contactnumber1 { get; set; }

        [DisplayName("Contact 2")]
        public string Contactnumber2 { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}
