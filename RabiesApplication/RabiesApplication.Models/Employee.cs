using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RabiesApplication.Models
{
    public class Employee : IModel, IOrganizationModel, IEmployeeBase, IAuditable
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Organization")]
        public Organization Organization { get; set; }

        [Required]
        public string OrganizationId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public override string ToString()
        {
            return string.Format("{1}, {0}", FirstName, LastName);
        }

        [DisplayName("Home Phone")]
        public string Phone { get; set; }


        public string Extension { get; set; }

        [DisplayName("Cell Phone")]
        public string MobilePhone { get; set; }

        public string Website { get; set; }

        public string HouseNumber { get; set; }


        public string StreetPrefix { get; set; }


        public string StreetName { get; set; }


        public string StreetSuffix { get; set; }


        public string Address2 { get; set; }


        public string CityName { get; set; }

        [DisplayName("State")]
        public string StateAbbreviation { get; set; }

        [DisplayName("Zip Code")]
        public string Zip5 { get; set; }


        public string Zip4 { get; set; }

        public byte Active { get; set; }


        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateEdited { get; set; }
        public string MemberCreatedId { get; set; }
        public string MemberEditedId { get; set; }
    }
}
