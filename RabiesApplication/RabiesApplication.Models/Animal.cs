using System;
using System.ComponentModel.DataAnnotations.Schema;
using RabiesApplication.Models;

namespace RabiesApp.Models
{
    public class Animal : IModel
    {

        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        public string BiteId { get; set; }

        public Bite Bite { get; set; }


        public string VetId { get; set; }
        public Vet Vet { get; set; }

        public bool IsVictim { get; set; }

        public string SpeciesId { get; set; }

        public Species Species { get; set; }

        public string BreedId { get; set; }
        public Breed Breed { get; set; }

        public string  Name { get; set; }

        //Todo check if needs to add SprayNeuter
        public bool Sex { get; set; }


        public bool IsVacinated { get; set; }

        public DateTime? VaccineDate { get; set; }
        public DateTime? VaccineExpirationDate { get; set; }

        public int? TagNumber { get; set; }

        public bool IsVacinatedPost { get; set; }
        public bool IsVacinatedPrior { get; set; }


        public bool IsQuarantine { get; set; }

        public bool IsQuarantineCompleted { get; set; }

        public string QuarantineVerification { get; set; }

        public string EmployeecreatedId { get; set; }
        public string EmployeeeditedId { get; set; }
        public DateTimeOffset Recordcreated { get; set; }
        public DateTimeOffset? Recordedited { get; set; }
    }
}
