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
        public int Id { get; set; }
        public int BiteId { get; set; }
        public Bite Bite { get; set; }

        public string QuarantineLetterSent { get; set; }

        public DateTime LetterSentDate { get; set; }

        public int FollowUpDays { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public int EmployeeCreatedId { get; set; }
        public int EmployeeEditedId { get; set; }
    }
}