using System;

namespace RabiesApplication.Models.Interfaces
{
    public interface IAuditable
    {
        DateTimeOffset RecordCreated { get; set; }

        DateTimeOffset? RecordEdited { get; set; }

        string EmployeeCreatedId { get; set; }

        string EmployeeEditedId { get; set; }
    }
}
