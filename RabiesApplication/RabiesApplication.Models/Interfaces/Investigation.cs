﻿using System;

namespace RabiesApplication.Models.Interfaces
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

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}