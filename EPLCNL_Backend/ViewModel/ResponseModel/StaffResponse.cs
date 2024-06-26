﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ResponseModel
{
    public class StaffResponse
    {
        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }
        public virtual AccountResponse? Account { get; set; }
    }
}
