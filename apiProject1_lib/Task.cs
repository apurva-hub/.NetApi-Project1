﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace apiProject1_lib
{
    public partial class Task
    {
        public long TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool? TaskStatus { get; set; }
        public DateTime? TaskDueDate { get; set; }
        public long? UserId { get; set; }
        public long? ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Register User { get; set; }
    }
}