using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabiesApplication.Web.Models
{
    public class BitesViewModel
    {
        public string Id { get; set; }
        public string PetOwner { get; set; }
        public string AnimalId { get; set; }
        public string AnimalName { get; set; }
        [DisplayFormat(DataFormatString = Constant.DateFormat)]
        public DateTimeOffset? BiteDate { get; set; }
        public string City { get; set; }
        public string VictimName { get; set; }
        public string Status { get; set; }
        [DisplayFormat(DataFormatString = Constant.DateFormat)]
        public DateTimeOffset RecordCreated { get; set; }
    }
}
