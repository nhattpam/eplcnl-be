﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Data.Models
{
    public partial class nhatpmseContext : DbContext
    {
        public nhatpmseContext()
        {
        }

        public nhatpmseContext(DbContextOptions<nhatpmseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountForum> AccountForums { get; set; } = null!;
        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<AssignmentAttempt> AssignmentAttempts { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Center> Centers { get; set; } = null!;
        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<ClassLesson> ClassLessons { get; set; } = null!;
        public virtual DbSet<ClassModule> ClassModules { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Forum> Forums { get; set; } = null!;
        public virtual DbSet<Learner> Learners { get; set; } = null!;
        public virtual DbSet<LearnerAttendance> LearnerAttendances { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Module> Modules { get; set; } = null!;
        public virtual DbSet<PaperWork> PaperWorks { get; set; } = null!;
        public virtual DbSet<PaperWorkType> PaperWorkTypes { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<PeerReview> PeerReviews { get; set; } = null!;
        public virtual DbSet<ProfileCertificate> ProfileCertificates { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<QuizAttempt> QuizAttempts { get; set; } = null!;
        public virtual DbSet<RefundHistory> RefundHistories { get; set; } = null!;
        public virtual DbSet<RefundRequest> RefundRequests { get; set; } = null!;
        public virtual DbSet<RefundSurvey> RefundSurveys { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<Tutor> Tutors { get; set; } = null!;
        public virtual DbSet<Wallet> Wallets { get; set; } = null!;
        public virtual DbSet<WalletHistory> WalletHistories { get; set; } = null!;
        public virtual DbSet<Staff> Staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", true, true);
                IConfigurationRoot configuration = builder.Build();
                string _connectionString = configuration.GetConnectionString("MyCnn");
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.ImageUrl)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Note)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account__role_id__04273924");
            });

            modelBuilder.Entity<AccountForum>(entity =>
            {
                entity.ToTable("AccountForum");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ForumId).HasColumnName("forum_id");

                entity.Property(e => e.LearnerId).HasColumnName("learner_id");

                entity.Property(e => e.Message)
                    .IsUnicode(false)
                    .HasColumnName("message");

                entity.Property(e => e.MessagedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("messaged_date");

                entity.Property(e => e.TutorId).HasColumnName("tutor_id");

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.AccountForums)
                    .HasForeignKey(d => d.ForumId)
                    .HasConstraintName("FK__AccountFo__forum__09E0127A");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.AccountForums)
                    .HasForeignKey(d => d.LearnerId)
                    .HasConstraintName("FK__AccountFo__learn__0BC85AEC");

                entity.HasOne(d => d.Tutor)
                    .WithMany(p => p.AccountForums)
                    .HasForeignKey(d => d.TutorId)
                    .HasConstraintName("FK__AccountFo__tutor__0AD436B3");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.ToTable("Assignment");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Deadline).HasColumnName("deadline");

                entity.Property(e => e.GradeToPass).HasColumnName("grade_to_pass");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModuleId).HasColumnName("module_id");

                entity.Property(e => e.QuestionAudioUrl)
                    .IsUnicode(false)
                    .HasColumnName("question_audio_url");

                entity.Property(e => e.QuestionText)
                    .IsUnicode(false)
                    .HasColumnName("question_text");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK__Assignmen__modul__13697CB4");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__Assignmen__topic__145DA0ED");
            });

            modelBuilder.Entity<AssignmentAttempt>(entity =>
            {
                entity.ToTable("AssignmentAttempt");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AnswerAudioUrl)
                    .IsUnicode(false)
                    .HasColumnName("answer_audio_url");

                entity.Property(e => e.AnswerText)
                    .IsUnicode(false)
                    .HasColumnName("answer_text");

                entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");

                entity.Property(e => e.AttemptedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("attempted_date");

                entity.Property(e => e.LearnerId).HasColumnName("learner_id");

                entity.Property(e => e.TotalGrade).HasColumnName("total_grade");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.AssignmentAttempts)
                    .HasForeignKey(d => d.AssignmentId)
                    .HasConstraintName("FK__Assignmen__assig__1A167A43");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.AssignmentAttempts)
                    .HasForeignKey(d => d.LearnerId)
                    .HasConstraintName("FK__Assignmen__learn__1B0A9E7C");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.HasIndex(e => e.ClassModuleId, "UQ__Attendan__C6F5C3FB7EBEB5E8")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ClassModuleId).HasColumnName("class_module_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.ClassModule)
                    .WithOne(p => p.Attendance)
                    .HasForeignKey<Attendance>(d => d.ClassModuleId)
                    .HasConstraintName("FK__Attendanc__class__34CA707F");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Center>(entity =>
            {
                entity.ToTable("Center");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.StaffId).HasColumnName("Staff_id");

                entity.Property(e => e.TaxIdentificationNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tax_identification_number");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Centers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Center__account___07F7CA08");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Centers)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Center__Staff_id__2E1D72F0");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.HasIndex(e => e.CourseId, "UQ__Certific__8F1EF7AF21C7B0E2")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Course)
                    .WithOne(p => p.Certificate)
                    .HasForeignKey<Certificate>(d => d.CourseId)
                    .HasConstraintName("FK__Certifica__cours__0CBC7F25");
            });

            modelBuilder.Entity<ClassLesson>(entity =>
            {
                entity.ToTable("ClassLesson");

                entity.HasIndex(e => e.ClassModuleId, "UQ__ClassLes__C6F5C3FB2E8DB525")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ClassHours)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("class_hours");

                entity.Property(e => e.ClassModuleId).HasColumnName("class_module_id");

                entity.Property(e => e.ClassUrl)
                    .IsUnicode(false)
                    .HasColumnName("class_url");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.ClassModule)
                    .WithOne(p => p.ClassLesson)
                    .HasForeignKey<ClassLesson>(d => d.ClassModuleId)
                    .HasConstraintName("FK__ClassLess__class__2958BDD3");
            });

            modelBuilder.Entity<ClassModule>(entity =>
            {
                entity.ToTable("ClassModule");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.ClassModules)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__ClassModu__cours__267C5128");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.ImageUrl)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsOnlineClass).HasColumnName("is_online_class");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Note)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.StockPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("stock_price");

                entity.Property(e => e.Tags)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tags");

                entity.Property(e => e.TutorId).HasColumnName("tutor_id");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Course__category__25882CEF");

                entity.HasOne(d => d.Tutor)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TutorId)
                    .HasConstraintName("FK__Course__tutor_id__0703A5CF");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");

                entity.HasIndex(e => e.TransactionId, "UQ__Enrollme__85C600AED492E343")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.EnrolledDate)
                    .HasColumnType("datetime")
                    .HasColumnName("enrolled_date");

                entity.Property(e => e.RefundStatus).HasColumnName("refund_status");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TotalGrade).HasColumnName("total_grade");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.HasOne(d => d.Transaction)
                    .WithOne(p => p.Enrollment)
                    .HasForeignKey<Enrollment>(d => d.TransactionId)
                    .HasConstraintName("FK__Enrollmen__trans__060F8196");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.FeedbackContent)
                    .IsUnicode(false)
                    .HasColumnName("feedback_content");

                entity.Property(e => e.LearnerId).HasColumnName("learner_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Feedback__course__249408B6");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.LearnerId)
                    .HasConstraintName("FK__Feedback__learne__239FE47D");
            });

            modelBuilder.Entity<Forum>(entity =>
            {
                entity.ToTable("Forum");

                entity.HasIndex(e => e.CourseId, "UQ__Forum__8F1EF7AF35E1BD6C")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.HasOne(d => d.Course)
                    .WithOne(p => p.Forum)
                    .HasForeignKey<Forum>(d => d.CourseId)
                    .HasConstraintName("FK__Forum__course_id__08EBEE41");
            });

            modelBuilder.Entity<Learner>(entity =>
            {
                entity.ToTable("Learner");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Learners)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Learner__account__2C352A7E");
            });

            modelBuilder.Entity<LearnerAttendance>(entity =>
            {
                entity.ToTable("LearnerAttendance");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");

                entity.Property(e => e.Attended).HasColumnName("attended");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.LearnerId).HasColumnName("learner_id");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.LearnerAttendances)
                    .HasForeignKey(d => d.AttendanceId)
                    .HasConstraintName("FK__LearnerAt__atten__35BE94B8");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.LearnerAttendances)
                    .HasForeignKey(d => d.LearnerId)
                    .HasConstraintName("FK__LearnerAt__learn__36B2B8F1");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModuleId).HasColumnName("module_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Reading)
                    .IsUnicode(false)
                    .HasColumnName("reading");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.Property(e => e.VideoUrl)
                    .IsUnicode(false)
                    .HasColumnName("video_url");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK__Lesson__module_i__108D1009");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.LessonId).HasColumnName("lesson_id");

                entity.Property(e => e.MaterialUrl)
                    .IsUnicode(false)
                    .HasColumnName("material_url");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__Material__lesson__1922560A");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__Material__topic___2864999A");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Modules)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Module__course_i__1551C526");
            });

            modelBuilder.Entity<PaperWork>(entity =>
            {
                entity.ToTable("PaperWork");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PaperWorkTypeId).HasColumnName("paper_work_type_id");

                entity.Property(e => e.PaperWorkUrl)
                    .IsUnicode(false)
                    .HasColumnName("paper_work_url");

                entity.Property(e => e.TutorId).HasColumnName("tutor_id");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.PaperWorkType)
                    .WithMany(p => p.PaperWorks)
                    .HasForeignKey(d => d.PaperWorkTypeId)
                    .HasConstraintName("FK__PaperWork__paper__21B79C0B");

                entity.HasOne(d => d.Tutor)
                    .WithMany(p => p.PaperWorks)
                    .HasForeignKey(d => d.TutorId)
                    .HasConstraintName("FK__PaperWork__tutor__22ABC044");
            });

            modelBuilder.Entity<PaperWorkType>(entity =>
            {
                entity.ToTable("PaperWorkType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PeerReview>(entity =>
            {
                entity.ToTable("PeerReview");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AssignmentAttemptId).HasColumnName("assignment_attempt_id");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.LearnerId).HasColumnName("learner_id");

                entity.HasOne(d => d.AssignmentAttempt)
                    .WithMany(p => p.PeerReviews)
                    .HasForeignKey(d => d.AssignmentAttemptId)
                    .HasConstraintName("FK__PeerRevie__assig__1CF2E6EE");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.PeerReviews)
                    .HasForeignKey(d => d.LearnerId)
                    .HasConstraintName("FK__PeerRevie__learn__1BFEC2B5");
            });

            modelBuilder.Entity<ProfileCertificate>(entity =>
            {
                entity.ToTable("ProfileCertificate");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CertificateId).HasColumnName("certificate_id");

                entity.Property(e => e.LearnerId).HasColumnName("learner_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Certificate)
                    .WithMany(p => p.ProfileCertificates)
                    .HasForeignKey(d => d.CertificateId)
                    .HasConstraintName("FK__ProfileCe__certi__0EA4C797");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.ProfileCertificates)
                    .HasForeignKey(d => d.LearnerId)
                    .HasConstraintName("FK__ProfileCe__learn__0DB0A35E");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.DefaultGrade).HasColumnName("default_grade");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.QuestionAudioUrl)
                    .IsUnicode(false)
                    .HasColumnName("question_audio_url");

                entity.Property(e => e.QuestionImageUrl)
                    .IsUnicode(false)
                    .HasColumnName("question_image_url");

                entity.Property(e => e.QuestionText)
                    .IsUnicode(false)
                    .HasColumnName("question_text");

                entity.Property(e => e.QuizId).HasColumnName("quiz_id");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__Question__quiz_i__1645E95F");
            });

            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.ToTable("QuestionAnswer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AnswerText)
                    .IsUnicode(false)
                    .HasColumnName("answer_text");

                entity.Property(e => e.IsAnswer).HasColumnName("is_answer");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__QuestionA__quest__0F98EBD0");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Deadline).HasColumnName("deadline");

                entity.Property(e => e.GradeToPass).HasColumnName("grade_to_pass");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModuleId).HasColumnName("module_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK__Quiz__module_id__11813442");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__Quiz__topic_id__1275587B");
            });

            modelBuilder.Entity<QuizAttempt>(entity =>
            {
                entity.ToTable("QuizAttempt");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AttemptedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("attempted_date");

                entity.Property(e => e.LearnerId).HasColumnName("learner_id");

                entity.Property(e => e.QuizId).HasColumnName("quiz_id");

                entity.Property(e => e.TotalGrade).HasColumnName("total_grade");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.QuizAttempts)
                    .HasForeignKey(d => d.LearnerId)
                    .HasConstraintName("FK__QuizAttem__learn__182E31D1");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizAttempts)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__QuizAttem__quiz___173A0D98");
            });

            modelBuilder.Entity<RefundHistory>(entity =>
            {
                entity.ToTable("RefundHistory");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.Note)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.RefundRequestId).HasColumnName("refund_request_id");

                entity.HasOne(d => d.RefundRequest)
                    .WithMany(p => p.RefundHistories)
                    .HasForeignKey(d => d.RefundRequestId)
                    .HasConstraintName("FK__RefundHis__refun__31EE03D4");
            });

            modelBuilder.Entity<RefundRequest>(entity =>
            {
                entity.ToTable("RefundRequest");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ApprovedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("approved_date");

                entity.Property(e => e.EnrollmentId).HasColumnName("enrollment_id");

                entity.Property(e => e.RequestedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("requested_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.RefundRequests)
                    .HasForeignKey(d => d.EnrollmentId)
                    .HasConstraintName("FK__RefundReq__enrol__20C377D2");
            });

            modelBuilder.Entity<RefundSurvey>(entity =>
            {
                entity.ToTable("RefundSurvey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Reason)
                    .IsUnicode(false)
                    .HasColumnName("reason");

                entity.Property(e => e.RefundRequestId).HasColumnName("refund_request_id");

                entity.HasOne(d => d.RefundRequest)
                    .WithMany(p => p.RefundSurveys)
                    .HasForeignKey(d => d.RefundRequestId)
                    .HasConstraintName("FK__RefundSur__refun__33D64C46");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.ImageUrl)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.LearnerId).HasColumnName("learner_id");

                entity.Property(e => e.Reason)
                    .IsUnicode(false)
                    .HasColumnName("reason");

                entity.Property(e => e.ReportedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("reported_date");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Report__course_i__3005BB62");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.LearnerId)
                    .HasConstraintName("FK__Report__learner___30F9DF9B");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("Salary");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Note)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("payment_date");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Salary__account___37A6DD2A");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ClassLessonId).HasColumnName("class_lesson_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.ClassLesson)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.ClassLessonId)
                    .HasConstraintName("FK__Topic__class_les__27707561");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.LearnerId).HasColumnName("learner_id");

                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("transaction_date");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Transacti__cours__1EDB2F60");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.LearnerId)
                    .HasConstraintName("FK__Transacti__learn__1DE70B27");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK__Transacti__payme__1FCF5399");
            });

            modelBuilder.Entity<Tutor>(entity =>
            {
                entity.ToTable("Tutor");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CenterId).HasColumnName("center_id");

                entity.Property(e => e.IsFreelancer).HasColumnName("is_freelancer");

                entity.Property(e => e.StaffId).HasColumnName("Staff_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Tutors)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Tutor__account_i__2A4CE20C");

                entity.HasOne(d => d.Center)
                    .WithMany(p => p.Tutors)
                    .HasForeignKey(d => d.CenterId)
                    .HasConstraintName("FK__Tutor__center_id__2D294EB7");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Tutors)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Tutor__Staff_id__2F119729");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.HasIndex(e => e.AccountId, "UQ__Wallet__46A222CCE421CA36")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("balance");

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Wallet)
                    .HasForeignKey<Wallet>(d => d.AccountId)
                    .HasConstraintName("FK__Wallet__account___051B5D5D");
            });

            modelBuilder.Entity<WalletHistory>(entity =>
            {
                entity.ToTable("WalletHistory");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Note)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("transaction_date");

                entity.Property(e => e.WalletId).HasColumnName("wallet_id");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.WalletHistories)
                    .HasForeignKey(d => d.WalletId)
                    .HasConstraintName("FK__WalletHis__walle__32E2280D");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Staff__account_i__2B410645");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
