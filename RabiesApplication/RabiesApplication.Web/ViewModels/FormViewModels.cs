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

}
