﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.RequestModel
{
    public class TutorRequest
    {
        public Guid? AccountId { get; set; }
        public bool? IsFreelancer { get; set; }
        public Guid? CenterId { get; set; }
        public Guid? StaffId { get; set; }
    }
}
