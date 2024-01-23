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
        public Guid? ClassPracticeId { get; set; }
        public string? Name { get; set; }
        public double? GradeToPass { get; set; }
        public TimeSpan? Deadline { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
