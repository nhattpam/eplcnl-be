﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Models;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace Service.CoursesService
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CourseResponse>> GetAll()
        {

            var list = await _unitOfWork.Repository<Course>().GetAll()
                                            .ProjectTo<CourseResponse>(_mapper.ConfigurationProvider)
                                            .ToListAsync();
            return list;
        }

        public async Task<CourseResponse> Get(Guid id)
        {
            try
            {
                Course course = null;
                course = await _unitOfWork.Repository<Course>().GetAll()
                     .AsNoTracking()
                         .Include(a => a.Certificate)
                        .Include(a => a.Category)
                        .Include(a => a.Tutor)
                         .ThenInclude(a => a.Account)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (course == null)
                {
                    throw new Exception("khong tim thay");
                }

                return _mapper.Map<Course, CourseResponse>(course);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       

        public async Task<CourseResponse> Create(CourseRequest request)
        {
            // Set the UTC offset for UTC+7
            TimeSpan utcOffset = TimeSpan.FromHours(7);

            // Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Convert the UTC time to UTC+7
            DateTime localTime = utcNow + utcOffset;
            try
            {
                var course = _mapper.Map<CourseRequest, Course>(request);
                course.Id = Guid.NewGuid();
                course.CreatedDate = localTime;
                course.IsActive = false;
                course.Rating = 0;
                await _unitOfWork.Repository<Course>().InsertAsync(course);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Course, CourseResponse>(course);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<CourseResponse> Delete(Guid id)
        {
            try
            {
                Course course = null;
                course = _unitOfWork.Repository<Course>()
                    .Find(p => p.Id == id);
                if (course == null)
                {
                    throw new Exception("Bi trung id");
                }
                await _unitOfWork.Repository<Course>().HardDeleteGuid(course.Id);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<Course, CourseResponse>(course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CourseResponse> Update(Guid id, CourseRequest request)
        {
            // Set the UTC offset for UTC+7
            TimeSpan utcOffset = TimeSpan.FromHours(7);

            // Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Convert the UTC time to UTC+7
            DateTime localTime = utcNow + utcOffset;
            try
            {
                Course course = _unitOfWork.Repository<Course>()
                            .Find(x => x.Id == id);
                if (course == null)
                {
                    throw new Exception();
                }
                course = _mapper.Map(request, course);
                course.UpdatedDate = localTime;

                await _unitOfWork.Repository<Course>().UpdateDetached(course);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Course, CourseResponse>(course);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ModuleResponse>> GetAllModulesByCourse(Guid id)
        {
            var course = await _unitOfWork.Repository<Course>().GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                // Handle the case where the center with the specified id is not found
                return null;
            }

            var modules = _unitOfWork.Repository<Module>().GetAll()
                .Where(t => t.CourseId == id)
                .ProjectTo<ModuleResponse>(_mapper.ConfigurationProvider)
                .ToList();

            return modules;
        }

        public async Task<List<ClassModuleResponse>> GetAllClassModulesByCourse(Guid id)
        {
            var course = await _unitOfWork.Repository<Course>().GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                // Handle the case where the center with the specified id is not found
                return null;
            }

            var modules = _unitOfWork.Repository<ClassModule>().GetAll()
                .Where(t => t.CourseId == id)
                .ProjectTo<ClassModuleResponse>(_mapper.ConfigurationProvider)
                .ToList();

            return modules;
        }
        public async Task<List<FeedbackResponse>> GetAllFeedbacksByCourse(Guid id)
        {
            var course = await _unitOfWork.Repository<Course>().GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                // Handle the case where the center with the specified id is not found
                return null;
            }

            var feedbacks = _unitOfWork.Repository<Feedback>().GetAll()
                .Where(t => t.CourseId == id)
                .ProjectTo<FeedbackResponse>(_mapper.ConfigurationProvider)
                .ToList();

            return feedbacks;
        }


        public async Task<List<EnrollmentResponse>> GetAllEnrollmentsByCourse(Guid id)
        {
            // Retrieve the course
            var course = await _unitOfWork.Repository<Course>().GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                // Handle the case where the course with the specified id is not found
                return null;
            }

            // Retrieve enrollments for the course
            var enrollments = await _unitOfWork.Repository<Enrollment>().GetAll()
                .Where(t => t.Transaction.CourseId == id)
                .ProjectTo<EnrollmentResponse>(_mapper.ConfigurationProvider)
                                            .ToListAsync();

            return enrollments;
        }

        public async Task<CertificateResponse> GetCertificateCourse(Guid id)
        {
            // Retrieve the course
            var course = await _unitOfWork.Repository<Course>().GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                // Handle the case where the course with the specified id is not found
                return null;
            }

            // Retrieve certificate for the course
            var certificate = await _unitOfWork.Repository<Certificate>().GetAll()
                .Where(t => t.CourseId == id)
                .ProjectTo<CertificateResponse>(_mapper.ConfigurationProvider)
                                            .FirstOrDefaultAsync();

            return certificate;
        }
        

    }
}
