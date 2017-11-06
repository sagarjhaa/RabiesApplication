using System;
using RabiesApplication.Models.Interfaces;

namespace RabiesApplication.Models
{
    public class Investigation : IModel
    {
        public string Id { get; set; }
        public string BiteId { get; set; }
        public Bite Bite { get; set; }

        public string QuarantineLetterSent { get; set; }

        public DateTime LetterSentDate { get; set; }

        public int FollowUpDays { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}