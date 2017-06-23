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
    public class Vet : IActive,IModel,IPerson
    {

        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

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

        public string Comments { get; set; }

        public bool IsActive { get; set; }
        public string EmployeecreatedId { get; set; }


        public string EmployeeeditedId { get; set; }
        public DateTimeOffset Recordcreated { get; set; }
        public DateTimeOffset? Recordedited { get; set; }

        public IEnumerable<Animal> Animals { get; set; }
        public bool Active { get; set; }
    }
}
