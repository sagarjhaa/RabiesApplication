using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;

namespace RabiesApp.Models
{
    public class PetOwner: IModel,IPerson,IAuditable
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        public int AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        public Animal Animal { get; set; }

        public bool IsShelter { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? Dateofbirth { get; set; }
        public int? Age { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }

        public int CountyId { get; set; }
        public int StateId { get; set; }

        public State State { get; set; }

        public int Zipcode { get; set; }
        public string Contactnumber1 { get; set; }
        public string Contactnumber2 { get; set; }


        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}
