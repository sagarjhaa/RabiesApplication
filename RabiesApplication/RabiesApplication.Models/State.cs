using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;

namespace RabiesApp.Models
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
