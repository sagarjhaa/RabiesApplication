using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class BiteStatus :IModel, IActive
    {
        [Key]
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Active { get; set; }

    }
}
