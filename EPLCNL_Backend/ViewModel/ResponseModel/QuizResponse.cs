﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ResponseModel
{
    public class QuizResponse
    {
        public Guid Id { get; set; }
        public Guid? ModuleId { get; set; }
        public Guid? TopicId { get; set; }
        public string? Name { get; set; }
        public double? GradeToPass { get; set; }
        public int? Deadline { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public virtual ModuleResponse? Module { get; set; }
        public virtual TopicResponse? Topic { get; set; }

    }
}
