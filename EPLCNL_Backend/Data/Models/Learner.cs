﻿using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Learner
    {
        public Learner()
        {
            AccountForums = new HashSet<AccountForum>();
            AssignmentAttempts = new HashSet<AssignmentAttempt>();
            Feedbacks = new HashSet<Feedback>();
            ProfileCertificates = new HashSet<ProfileCertificate>();
            QuizAttempts = new HashSet<QuizAttempt>();
            Reports = new HashSet<Report>();
            Transactions = new HashSet<Transaction>();
        }

        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<AccountForum> AccountForums { get; set; }
        public virtual ICollection<AssignmentAttempt> AssignmentAttempts { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<ProfileCertificate> ProfileCertificates { get; set; }
        public virtual ICollection<QuizAttempt> QuizAttempts { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
