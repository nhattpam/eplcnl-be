﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ResponseModel
{
    public class RefundResponse
    {
        public Guid Id { get; set; }
        public Guid? TransactionId { get; set; }
        public DateTime? RequestedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Status { get; set; }
        public string? Reason { get; set; }

        public virtual TransactionResponse? Transaction { get; set; }
    }
}
