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

namespace Service.QuizAttemptsService
{
    public class QuizAttemptService : IQuizAttemptService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public QuizAttemptService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<QuizAttemptResponse>> GetQuizAttempts()
        {

            var list = await _unitOfWork.Repository<QuizAttempt>().GetAll()
                                            .ProjectTo<QuizAttemptResponse>(_mapper.ConfigurationProvider)
                                            .ToListAsync();
            return list;
        }

        public async Task<QuizAttemptResponse> Create(QuizAttemptRequest request)
        {
            try
            {
                var quizAttempt = _mapper.Map<QuizAttemptRequest, QuizAttempt>(request);
                quizAttempt.Id = Guid.NewGuid();
                await _unitOfWork.Repository<QuizAttempt>().InsertAsync(quizAttempt);
                await _unitOfWork.CommitAsync();

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
    }
}
