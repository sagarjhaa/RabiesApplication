using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace RabiesApplication.Models
{
    public class Organization : IModel, IOrganizationBase
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string StreetAddress1 { get; set; }
        [Display(Name = " ")]
        public string StreetAddress2 { get; set; }
        public string Suite { get; set; }
        [Microsoft.Build.Framework.Required]
        public string City { get; set; }
        [Microsoft.Build.Framework.Required]
        [Display(Name = "State Province")]
        public string StateProvince { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Microsoft.Build.Framework.Required]
        public string Status { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public ICollection<Employee> Members { get; set; }
    }


}
