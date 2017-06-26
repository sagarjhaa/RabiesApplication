using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class City :IModel, IActive
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        [Required]
        public string CityName { get; set; }
       
        public int StateId { get; set; }
        public State State { get; set; }

        public bool Active { get; set; }

    }
}
