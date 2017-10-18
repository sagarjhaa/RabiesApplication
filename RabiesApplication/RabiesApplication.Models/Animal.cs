using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RabiesApplication.Models;
using RabiesApplication.Models.CustomValidation;
using RabiesApplication.Models.Interfaces;

namespace RabiesApplication.Models
{
    public class Animal : IModel,IAuditable
    {
        public string Id { get; set; }

        [ForeignKey("AnimalOwner")]
        public string AnimalOwnerId { get; set; }

        public AnimalOwner AnimalOwner { get; set; }

        public virtual ICollection<Bite> Bites { get; set; }
        
        [DisplayName("Vet")]
        public string VetId { get; set; }

        public Vet Vet { get; set; }

        [Required]
        [DisplayName("Sepecies")]
        public string SpeciesId { get; set; }

        public Species Species { get; set; }

        //[Required]
        [DisplayName("Breed")]
        public string BreedId { get; set; }

        public Breed Breed { get; set; }

        public string  Name { get; set; }

        //Todo check if needs to add SprayNeuter
        public bool Sex { get; set; }

        [DisplayName("Vaccinated?")]
        public bool IsVacinated { get; set; }

        [IfVacinatedCheckDates]
        [DisplayName("Vaccine Date")]
        public DateTime? VaccineDate { get; set; }

        [IfVacinatedCheckDates]
        [DisplayName("Vacc. Expiration Date")]
        public DateTime? VaccineExpirationDate { get; set; }

        [DisplayName("Tag Number")]
        public int? TagNumber { get; set; }

        [DisplayName("Vaccine Post")]
        public bool IsVacinatedPost { get; set; }
        [DisplayName("Vaccine Prior")]
        public bool IsVacinatedPrior { get; set; }

        [DisplayName("Quarantine?")]
        public bool IsQuarantine { get; set; }

        [DisplayName("Quarantine Complete?")]
        public bool IsQuarantineCompleted { get; set; }

        [DisplayName("Quarantine Verification")]
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
            
        }
    }
}
