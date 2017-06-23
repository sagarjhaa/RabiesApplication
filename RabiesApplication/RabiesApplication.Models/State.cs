using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class State : IActive
    {

        public int Id { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public string  StateShortName { get; set; }

        

        public IEnumerable<City> Cities { get; set; }

        public IEnumerable<County> Counties { get; set; }
        public bool Active { get; set; }
    }
}
