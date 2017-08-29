namespace RabiesApplication.Models
{
    public interface IEmployeeBase
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
