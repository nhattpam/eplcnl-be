﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ResponseModel
{
    public class EnrollmentResponse
    {
        public Guid Id { get; set; }
        public Guid? LearnerId { get; set; }
        public Guid? CourseId { get; set; }
        public DateTime? EnrolledDate { get; set; }
        public string? Status { get; set; }
        public double? TotalGrade { get; set; }
    }
}