namespace RabiesApplication.Models.Interfaces
{
    public interface IModel
    {
        string Id { get; set; }
        byte[] RowVersion { get; set; }
    }
}
