﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Models;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Service.AssignmentAttemptsService;
using Service.CertificatesService;
using Service.CoursesService;
using Service.ModulesService;
using Service.ProfileCertificatesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace Service.QuizAttemptsService
{
    public class QuizAttemptService : IQuizAttemptService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IAssignmentAttemptService _assignmentAttemptService;
        private ICourseService _courseService;
        private IModuleService _moduleService;
        private ICertificateService _certificateService;
        private IProfileCertificateService _profileCertificateService;
        public QuizAttemptService(IUnitOfWork unitOfWork, IMapper mapper,
            IAssignmentAttemptService assignmentAttemptService
            , ICourseService courseService, IModuleService moduleService
            , ICertificateService certificateService, IProfileCertificateService profileCertificateService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _courseService = courseService;
            _assignmentAttemptService = assignmentAttemptService;
            _moduleService = moduleService;
            _certificateService = certificateService;
            _profileCertificateService = profileCertificateService;
        }

        public async Task<List<QuizAttemptResponse>> GetAll()
        {

            var list = await _unitOfWork.Repository<QuizAttempt>().GetAll()
                 .Include(x => x.Quiz)
                        .ThenInclude(x => x.Module)
                            .ThenInclude(x => x.Course)
                                            .ProjectTo<QuizAttemptResponse>(_mapper.ConfigurationProvider)
                                            .ToListAsync();
            return list;
        }

        public async Task<QuizAttemptResponse> Get(Guid id)
        {
            try
            {
                QuizAttempt quizAttempt = null;
                quizAttempt = await _unitOfWork.Repository<QuizAttempt>().GetAll()
                     .AsNoTracking()
                     .Include(x => x.Quiz)
                        .ThenInclude(x => x.Module)
                            .ThenInclude(x => x.Course)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (quizAttempt == null)
                {
                    throw new Exception("khong tim thay");
                }

                return _mapper.Map<QuizAttempt, QuizAttemptResponse>(quizAttempt);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<QuizAttemptResponse> Create(QuizAttemptRequest request)
        {
            // Set the UTC offset for UTC+7
            TimeSpan utcOffset = TimeSpan.FromHours(7);

            // Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Convert the UTC time to UTC+7
            DateTime localTime = utcNow + utcOffset;
            try
            {
                var quizAttempt = _mapper.Map<QuizAttemptRequest, QuizAttempt>(request);
                quizAttempt.Id = Guid.NewGuid();
                quizAttempt.AttemptedDate = localTime;
                await _unitOfWork.Repository<QuizAttempt>().InsertAsync(quizAttempt);
                await _unitOfWork.CommitAsync();

                double? courseScore = 0;
                var quizAttemptNow = await Get(quizAttempt.Id);
                var quizzes = await _moduleService.GetAllQuizzesByModule(quizAttemptNow.Quiz.ModuleId ?? new Guid());
                if (quizzes != null)
                {
                    foreach (var quizz in quizzes)
                    {
                        if (quizz != null && quizz.GradeToPass.HasValue && quizz.IsActive == true)
                        {
                            courseScore += quizz.GradeToPass.Value;
                        }
                        // Add handling if GradeToPass is null
                    }
                }

                var assignments = await _moduleService.GetAllAssignmentsByModule(quizAttemptNow.Quiz.ModuleId ?? new Guid());
                if (assignments != null)
                {
                    foreach (var assignment in assignments)
                    {
                        if (assignment != null && assignment.GradeToPass.HasValue && assignment.IsActive == true)
                        {
                            courseScore += assignment.GradeToPass.Value;
                        }
                        // Add handling if GradeToPass is null
                    }
                }

                double? score = 0;

                // Get the quiz attempts list asynchronously
                var quizAttempts = await GetAll();
                var filteredQuizAttempts = quizAttempts
                    .Where(x => x.LearnerId == quizAttemptNow.LearnerId
                    && x.Quiz.ModuleId == quizAttemptNow.Quiz.ModuleId
                    && x.Quiz.IsActive == true
                    ).ToList();
                var assignmentAttempts = await GetAllAssignmentAttempts();
                var filteredAssignmentAttempts = assignmentAttempts
                    .Where(x => x.LearnerId == quizAttemptNow.LearnerId
                    && x.Assignment.ModuleId == quizAttemptNow.Quiz.ModuleId
                    && x.Assignment.IsActive == true
                    ).ToList();

                // Find the quiz attempt with the highest TotalGrade
                var highestGradeAttemptQuiz = filteredQuizAttempts.OrderByDescending(x => x.TotalGrade).FirstOrDefault();

                if (highestGradeAttemptQuiz != null && quizAttemptNow.LearnerId == highestGradeAttemptQuiz.LearnerId)
                {
                    score += highestGradeAttemptQuiz.TotalGrade;
                }

                // Find the assignment attempt with the highest TotalGrade
                var highestGradeAttemptAssignment = filteredAssignmentAttempts.OrderByDescending(x => x.TotalGrade).FirstOrDefault();
                // Add the total grades of assignment attempts
                if (highestGradeAttemptAssignment != null && quizAttemptNow.LearnerId == highestGradeAttemptAssignment.LearnerId)
                {
                    score += highestGradeAttemptAssignment.TotalGrade;
                }

                var certificates = await _certificateService.GetAll();
                var profileCertificates = await _profileCertificateService.GetAll();
                var certificate = certificates.FirstOrDefault(x => x.CourseId == quizAttemptNow.Quiz.Module.CourseId);
                if (certificate != null && score >= courseScore)
                {
                    var existingProfileCertificate = profileCertificates.FirstOrDefault(pc => pc.LearnerId == quizAttemptNow.LearnerId && pc.CertificateId == certificate.Id);

                    if (existingProfileCertificate == null)
                    {
                        var profileCertificate = new ProfileCertificate()
                        {
                            LearnerId = quizAttemptNow.LearnerId,
                            CertificateId = certificate.Id,
                            Status = "DONE"
                        };

                        var profileCertificateRequest = _mapper.Map<ProfileCertificate, ProfileCertificateRequest>(profileCertificate);

                        // Assuming _profileCertificateService.Create method accepts ProfileCertificateRequest object
                        await _profileCertificateService.Create(profileCertificateRequest);
                    }

                }

                return _mapper.Map<QuizAttempt, QuizAttemptResponse>(quizAttempt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public async Task<QuizAttemptResponse> Delete(Guid id)
        {
            try
            {
                QuizAttempt quizAttempt = null;
                quizAttempt = _unitOfWork.Repository<QuizAttempt>()
                    .Find(p => p.Id == id);
                if (quizAttempt == null)
                {
                    throw new Exception("Bi trung id");
                }
                await _unitOfWork.Repository<QuizAttempt>().HardDeleteGuid(quizAttempt.Id);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<QuizAttempt, QuizAttemptResponse>(quizAttempt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizAttemptResponse> Update(Guid id, QuizAttemptRequest request)
        {
            try
            {
                QuizAttempt quizAttempt = _unitOfWork.Repository<QuizAttempt>()
                            .Find(x => x.Id == id);
                if (quizAttempt == null)
                {
                    throw new Exception();
                }
                quizAttempt = _mapper.Map(request, quizAttempt);

                await _unitOfWork.Repository<QuizAttempt>().UpdateDetached(quizAttempt);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<QuizAttempt, QuizAttemptResponse>(quizAttempt);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AssignmentAttemptResponse>> GetAllAssignmentAttempts()
        {

            var list = await _unitOfWork.Repository<AssignmentAttempt>().GetAll()
                 .Include(x => x.Assignment)
                        .ThenInclude(x => x.Module)
                            .ThenInclude(x => x.Course)
                                            .ProjectTo<AssignmentAttemptResponse>(_mapper.ConfigurationProvider)
                                            .ToListAsync();
            return list;
        }
    }
}
