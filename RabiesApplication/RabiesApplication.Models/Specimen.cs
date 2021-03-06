﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class Specimen:IModel,IAuditable
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int SpeciesId { get; set; }

        public Species Species { get; set; }

        public string SubmittedBy { get; set; }

        public DateTime? DateReceived { get; set; }


        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }

        public int ZipCode { get; set; }
        public string Phone1 { get; set; }

        public string  Phone2 { get; set; }

        public string AgencyTest { get; set; }

        public string Reason { get; set; }
        public string Result { get; set; }
        public string SubAgency { get; set; }
        public string SubCity { get; set; }
        public string SubPhone { get; set; }
        public string Comments { get; set; }

        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public string EmployeeCreatedId { get; set; }
        public string EmployeeEditedId { get; set; }
    }
}
