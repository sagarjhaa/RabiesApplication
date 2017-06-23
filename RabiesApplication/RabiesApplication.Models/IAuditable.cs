using System;

namespace RabiesApplication.Models
{
    public interface IAuditable
    {
        DateTimeOffset DateCreated { get; set; }

        DateTimeOffset? DateEdited { get; set; }

        string MemberCreatedId { get; set; }

        string MemberEditedId { get; set; }
    }
}
