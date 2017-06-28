using System;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? Dateofbirth { get; set; }
        public int? Age { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string CityId { get; set; }
        public City City { get; set; }

        public string CountyId { get; set; }
        public County County { get; set; }

        public string StateId { get; set; }
        public State State { get; set; }
        [Required]
        public int? Zipcode { get; set; }
        public string Contactnumber1 { get; set; }
        public string Contactnumber2 { get; set; }
        public bool BiteType { get; set; }
        public bool BiteTypeNonBite { get; set; }
        public bool PostExposureProphylaxis { get; set; }
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
