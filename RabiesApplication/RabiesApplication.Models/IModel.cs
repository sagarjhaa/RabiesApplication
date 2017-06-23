namespace RabiesApplication.Models
{
    public interface IModel
    {
        string Id { get; set; }
        byte[] RowVersion { get; set; }
    }
}
