﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public partial class Register
    {
        public Register()
        {
            Dosages = new HashSet<Dosage>();
            Projects = new HashSet<Project>();
            Tasks = new HashSet<Task>();
        }

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Dosage> Dosages { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}