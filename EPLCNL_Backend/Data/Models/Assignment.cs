﻿using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            AssignmentAttempts = new HashSet<AssignmentAttempt>();
        }

        public Guid Id { get; set; }
        public string? QuestionText { get; set; }
        public string? QuestionAudioUrl { get; set; }
        public int? Deadline { get; set; }
        public Guid? ModuleId { get; set; }
        public Guid? TopicId { get; set; }
        public double? GradeToPass { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Module? Module { get; set; }
        public virtual Topic? Topic { get; set; }
        public virtual ICollection<AssignmentAttempt> AssignmentAttempts { get; set; }
    }
}
