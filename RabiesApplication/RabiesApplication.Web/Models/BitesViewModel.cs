using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabiesApplication.Web.Models
{
    public class BitesViewModel
    {
        public string Id { get; set; }
        public string PetOwner { get; set; }
        public string AnimalName { get; set; }
        public DateTimeOffset? BiteDate { get; set; }
        public string City { get; set; }
        public string VictimName { get; set; }
        public string Status { get; set; }
    }
}
