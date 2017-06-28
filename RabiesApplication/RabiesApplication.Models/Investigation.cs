using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{

    public class Investigation : IModel, IAuditable
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }
        public string BiteId { get; set; }
        public Bite Bite { get; set; }

        public string QuarantineLetterSent { get; set; }

        public DateTime LetterSentDate { get; set; }

        public int FollowUpDays { get; set; }
        public DateTime? InvestigationCompletionDate { get; set; }

        public DateTime? ReportClosedDate { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}