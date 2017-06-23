using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApp.Models
{
    public class City : IActive
    {
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }
       
        public int StateId { get; set; }
        public State State { get; set; }

        public bool Active { get; set; }
    }
}
