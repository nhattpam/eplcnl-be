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

namespace Service.LessonsService
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<LessonResponse>> GetAll()
        {

            var list = await _unitOfWork.Repository<Lesson>().GetAll()
                                            .ProjectTo<LessonResponse>(_mapper.ConfigurationProvider)
                                            .ToListAsync();
            return list;
        }

        public async Task<LessonResponse> Create(LessonRequest request)
        {
            try
            {
                var lesson = _mapper.Map<LessonRequest, Lesson>(request);
                lesson.Id = Guid.NewGuid();
                await _unitOfWork.Repository<Lesson>().InsertAsync(lesson);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Lesson, LessonResponse>(lesson);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LessonResponse> Delete(Guid id)
        {
            try
            {
                Lesson lesson = null;
                lesson = _unitOfWork.Repository<Lesson>()
                    .Find(p => p.Id == id);
                if (lesson == null)
                {
                    throw new Exception("Bi trung id");
                }
                await _unitOfWork.Repository<Lesson>().HardDeleteGuid(lesson.Id);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<Lesson, LessonResponse>(lesson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LessonResponse> Update(Guid id, LessonRequest request)
        {
            try
            {
                Lesson lesson = _unitOfWork.Repository<Lesson>()
                            .Find(x => x.Id == id);
                if (lesson == null)
                {
                    throw new Exception();
                }
                lesson = _mapper.Map(request, lesson);

                await _unitOfWork.Repository<Lesson>().UpdateDetached(lesson);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Lesson, LessonResponse>(lesson);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}