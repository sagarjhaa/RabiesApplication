using System;
using System.ComponentModel.DataAnnotations.Schema;
using RabiesApplication.Models;

namespace RabiesApp.Models
{
    public class HumanVictim : IPerson, IModel
    {

        public string Id { get; set; }
        public byte[] RowVersion { get; set; }
        public int BiteId { get; set; }
        public Bite Bite { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? Dateofbirth { get; set; }
        public int? Age { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public int CityId { get; set; }
        public int CountyId { get; set; }
        public int StateId { get; set; }
        public int Zipcode { get; set; }
        public string Contactnumber1 { get; set; }
        public string Contactnumber2 { get; set; }
        public bool BiteType { get; set; }
        public bool BiteTypeNonBite { get; set; }
        public bool PostExposureProphylaxis { get; set; }
        public string MedicalTreatmentProvider { get; set; }
        public string EmployeecreatedId { get; set; }
        public string EmployeeeditedId { get; set; }
        public DateTimeOffset Recordcreated { get; set; }
        public DateTimeOffset? Recordedited { get; set; }
    }
}
