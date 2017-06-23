using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApp.Models
{
    public class BiteStatus : IActive
    {

        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
