using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabiesApplication.Models
{
    public interface IPerson
    {
        [Required]
        string FirstName { get; set; }

        string LastName { get; set; }

        DateTimeOffset? Dateofbirth { get; set; }


        int? Age { get; set; }

        string Addressline1 { get; set; }
        string Addressline2 { get; set; }

        int CityId { get; set; }

        int CountyId { get; set; }

        int StateId { get; set; }

        int? Zipcode { get; set; }


        string Contactnumber1 { get; set; }
        string Contactnumber2 { get; set; }


    }
}
