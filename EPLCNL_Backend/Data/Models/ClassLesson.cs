﻿using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class ClassLesson
    {
        public ClassLesson()
        {
            Topics = new HashSet<Topic>();
        }

        public Guid Id { get; set; }
        public string? ClassHours { get; set; }
        public string? ClassUrl { get; set; }
        public Guid? ClassModuleId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ClassModule? ClassModule { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
