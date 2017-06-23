using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class County:IActive
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Fips { get; set; }
        public bool Active { get; set; }


        public int StateId { get; set; }

        public State State { get; set; }
    }
}
