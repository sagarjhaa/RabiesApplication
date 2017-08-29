using System;

namespace RabiesApplication.Models
{
    public interface IAuditable
    {
        DateTimeOffset RecordCreated { get; set; }

        DateTimeOffset? RecordEdited { get; set; }

        int EmployeeCreatedId { get; set; }

        int EmployeeEditedId { get; set; }
    }
}
