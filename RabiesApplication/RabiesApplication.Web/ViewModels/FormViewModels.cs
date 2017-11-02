using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Models.CustomValidation;

namespace RabiesApplication.Web.ViewModels
{
    public class BiteFormViewModel
    {
        public string Id { get; set; }
        //Which city the bite occured
        [DisplayName("City")]
        public string CityId { get; set; }
        
        //What state the bite occured
        //It will be Ohio for us
        [DisplayName("State")]
        public string StateId { get; set; }
        [Required]
        //When bite happened
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayName("Bite Date")]
        public DateTimeOffset? BiteDate { get; set; }
        [Required]
        //When it was reported to us
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Bite Report Date")]
        public DateTimeOffset? BiteReportDate { get; set; }
        //Where did we get this information from
        [DisplayName("Bite Reported By")]
        public string BiteReportedBy { get; set; }
        [DisplayName("Bite Status")]
        public string BiteStatusId { get; set; }
        public string Comments { get; set; }
        [DisplayName("Employee Assigned")]
        public string EmployeeAssignedId { get; set; }
        public bool Active { get; set; }
        [DisplayName("Investigation Complete Date")]
        public DateTime? InvestigationCompletionDate { get; set; }
        [DisplayName("Report Closed Date")]
        public DateTime? ReportClosedDate { get; set; }
        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }

        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<BiteStatus> BiteStatuses { get; set; }
        public Dictionary<string,string> Employees { get; set; }



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
    }


    public class HumanVictimFormViewModel
    {
        public string Id { get; set; }
        public string BiteId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string Email { get; set; }
        [Required]
        public int? Zipcode { get; set; }
        public string Contactnumber1 { get; set; }
        public string Contactnumber2 { get; set; }
        public DateTimeOffset? Dateofbirth { get; set; }
        public bool BiteType { get; set; }
        public bool BiteTypeNonBite { get; set; }
        public bool PostExposureProphylaxis { get; set; }
        public string MedicalTreatmentProvider { get; set; }
        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreated { get; set; }
        public string EmployeeEdited { get; set; }


        public string StateId { get; set; }
        public IEnumerable<State> States { get; set; }

        public string CityId { get; set; }
        public IEnumerable<City> Cities { get; set; }

        public string CountyId { get; set; }
        public IEnumerable<County> Counties { get; set; }

    }

    public class AnimalFormViewModel
    {
        public string Id { get; set; }
        public string BiteId { get; set; }
        public string AnimalOwnerId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string SpeciesId { get; set; }

        public string BreedId { get; set; }
        public string VetId { get; set; }
        public bool Sex { get; set; }
        
        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
        public IEnumerable<Species> Species { get; set; }
        public IEnumerable<Breed> Breed { get; set; }
        public IEnumerable<Vet> Vet { get; set; }

        public Dictionary<string,string> AnimalOwner { get; set; }

    }

    public class AnimalOwnerFormViewModel
    {
        public string Id { get; set; }

        [DisplayName("Shelter?")]
        public bool IsShelter { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public DateTimeOffset? Dateofbirth { get; set; }
        public int? Age { get; set; }

        [DisplayName("Addressline 1")]
        public string Addressline1 { get; set; }

        [DisplayName("Addressline 2")]
        public string Addressline2 { get; set; }

        [DisplayName("City")]
        public string CityId { get; set; }

        

        [DisplayName("County")]
        public string CountyId { get; set; }

        [DisplayName("State")]
        public string StateId { get; set; }


        [Required]
        public int? Zipcode { get; set; }

        [DisplayName("Primary Contact")]
        public string Contactnumber1 { get; set; }

        [DisplayName("Contact 2")]
        public string Contactnumber2 { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }

        public IEnumerable<State> States { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<County> Counties { get; set; }
    }

    public class VetFormViewModel
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        [Required]
        public int? Zipcode { get; set; }
        public string Contactnumber1 { get; set; }
        public string Contactnumber2 { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreated { get; set; }
        public string EmployeeEdited { get; set; }

        public string Comments { get; set; }

        public string StateId { get; set; }
        public IEnumerable<State> States { get; set; }

        public string CityId { get; set; }
        public IEnumerable<City> Cities { get; set; }

        public string CountyId { get; set; }
        public IEnumerable<County> Counties { get; set; }
        public bool Active { get; set; }
    }

}

