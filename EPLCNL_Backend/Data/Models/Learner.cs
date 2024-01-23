﻿using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Learner
    {
        public Learner()
        {
            AccountForums = new HashSet<AccountForum>();
            AccountSurveys = new HashSet<AccountSurvey>();
            AssignmentAttempts = new HashSet<AssignmentAttempt>();
            Enrollments = new HashSet<Enrollment>();
            ProfileCertificates = new HashSet<ProfileCertificate>();
            QuizAttempts = new HashSet<QuizAttempt>();
            Transactions = new HashSet<Transaction>();
        }

        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<AccountForum> AccountForums { get; set; }
        public virtual ICollection<AccountSurvey> AccountSurveys { get; set; }
        public virtual ICollection<AssignmentAttempt> AssignmentAttempts { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<ProfileCertificate> ProfileCertificates { get; set; }
        public virtual ICollection<QuizAttempt> QuizAttempts { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
