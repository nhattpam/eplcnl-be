﻿using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace Service.TutorService
{
    public interface ITutorService
    {
        Task<List<TutorResponse>> GetAll();
        Task<TutorResponse> Get(Guid id);
        Task<List<CourseResponse>> GetAllCoursesByTutor(Guid id);
        Task<List<PaperWorkResponse>> GetAllPaperWorksByTutor(Guid id);
        Task<List<ForumResponse>> GetAllForumsByTutor(Guid id);

        Task<List<AssignmentAttemptResponse>> GetAllAssignmentAttemptsByTutor(Guid tutorId);
        Task<List<EnrollmentResponse>> GetAllEnrollmentsByTutor(Guid id);
        Task<decimal> GetTotalAmountByTutor(Guid id);
        Task<List<LearnerResponse>> GetAllLearnersByTutor(Guid id);

        Task<TutorResponse> Create(TutorRequest request);
        Task<TutorResponse> Update(Guid id, TutorRequest request);
        Task<TutorResponse> Delete(Guid id);
    }
}