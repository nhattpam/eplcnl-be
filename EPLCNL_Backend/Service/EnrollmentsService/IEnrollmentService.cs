﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace Service.EnrollmentsService
{
    public interface IEnrollmentService
    {
        public Task<List<EnrollmentResponse>> GetAll();

        public Task<EnrollmentResponse> Get(Guid id);

        public Task<EnrollmentResponse> Create(EnrollmentRequest request);

        public Task<EnrollmentResponse> Delete(Guid id);

        public Task<EnrollmentResponse> Update(Guid id, EnrollmentRequest request);

        public Task<EnrollmentResponse> GetEnrollmentByLearnerAndCourseId(Guid learnerId, Guid courseId);
        public Task<EnrollmentResponse> DeleteEnrollmentByLearnerAndCourseId(Guid learnerId, Guid courseId);
        public Task<double?> GetCourseScore(Guid id);
        public Task<double?> GetLearningScore(Guid id);

        public Task CheckAndProcessEnrollmentsAsync();

        public Task ProcessEnrollmentAsync(EnrollmentResponse enrollment);

        public Task<EnrollmentResponse[]> GetEligibleEnrollmentsAsync();

        public bool Is60SecondsAfterEnrollment(EnrollmentResponse enrollment);

    }
}
