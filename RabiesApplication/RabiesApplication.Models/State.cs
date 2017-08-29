﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RabiesApplication.Models;

namespace RabiesApplication.Models
{
    public class State :IModel, IActive, IAuditable
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("State")]
        public string StateName { get; set; }
        [Required]
        public string  StateShortName { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public IEnumerable<County> Counties { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset RecordCreated { get; set; }
        public DateTimeOffset? RecordEdited { get; set; }
        public int EmployeeCreatedId { get; set; }
        public int EmployeeEditedId { get; set; }
    }
}
