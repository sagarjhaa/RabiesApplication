using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RabiesApplication.Models;
using RabiesApplication.Models.CustomValidation;

namespace RabiesApplication.Models
{
    public class Animal : IModel,IAuditable
    {

        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        public string BiteId { get; set; }

        public Bite Bite { get; set; }


        public string VetId { get; set; }
        public Vet Vet { get; set; }

        public bool IsVictim { get; set; }

        [Required]
        public string SpeciesId { get; set; }

        public Species Species { get; set; }
        [Required]
        public string BreedId { get; set; }
        public Breed Breed { get; set; }

        public string  Name { get; set; }

        //Todo check if needs to add SprayNeuter
        public bool Sex { get; set; }

        
        public bool IsVacinated { get; set; }
        [IfVacinatedCheckDates]
        public DateTime? VaccineDate { get; set; }
        [IfVacinatedCheckDates]
        public DateTime? VaccineExpirationDate { get; set; }

        public int? TagNumber { get; set; }

        public bool IsVacinatedPost { get; set; }
        public bool IsVacinatedPrior { get; set; }


        public bool IsQuarantine { get; set; }

        public bool IsQuarantineCompleted { get; set; }

        public string QuarantineVerification { get; set; }


        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }


        public Animal()
        {
            
        }

        public Animal(string biteId)
        {
            BiteId = biteId;
        }
    }
}
