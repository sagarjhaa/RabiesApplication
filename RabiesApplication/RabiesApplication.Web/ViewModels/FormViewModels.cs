using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;

namespace RabiesApplication.Web.ViewModels
{
    public class BiteFormViewModel
    {
        public Bite Bite { get; set; }

        public IEnumerable<State> States { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public Dictionary<string,string> Employees { get; set; }

        public IEnumerable<BiteStatus> BiteStatuses { get; set; }
    }


    public class HumanVictimFormViewModel
    {
        public string Id { get; set; }
        public string BiteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string Email { get; set; }
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
        public string Name { get; set; }
        public string SpeciesId { get; set; }
        public string BreedId { get; set; }
        public string VetId { get; set; }
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
        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
        public IEnumerable<Species> Species { get; set; }
        public IEnumerable<Breed> Breed { get; set; }
        public IEnumerable<Vet> Vet { get; set; }

    }

}
