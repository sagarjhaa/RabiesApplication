using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using RabiesApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace RabiesApplication.Models
{
    public class HumanVictim : IPerson, IModel,IAuditable,IActive
    {

        public string Id { get; set; }
        public byte[] RowVersion { get; set; }
        public string BiteId { get; set; }
        public Bite Bite { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date of birth")]
        public DateTimeOffset? Dateofbirth { get; set; }
        public int? Age { get; set; }
        [DisplayName("Addressline 1")]
        public string Addressline1 { get; set; }
        [DisplayName("Addressline 2")]
        public string Addressline2 { get; set; }
        [DisplayName("City")]
        public string CityId { get; set; }
        public City City { get; set; }
        [DisplayName("County")]
        public string CountyId { get; set; }
        public County County { get; set; }
        [DisplayName("State")]
        public string StateId { get; set; }
        public State State { get; set; }
        [Required]
        public int? Zipcode { get; set; }
        [DisplayName("Primary Contact")]
        public string Contactnumber1 { get; set; }
        [DisplayName("Contact 2")]
        public string Contactnumber2 { get; set; }
        [DisplayName("Bite type bite")]
        public bool BiteType { get; set; }
        [DisplayName("Non bite")]
        public bool BiteTypeNonBite { get; set; }
        [DisplayName("PEP")]
        public bool PostExposureProphylaxis { get; set; }
        [DisplayName("Med. treatment Provider")]
        public string MedicalTreatmentProvider { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
        public bool Active { get; set; }

        public HumanVictim()
        {
            
        }

        public HumanVictim(string biteId)
        {
            BiteId = biteId;
        }

    }
}
