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

namespace Service.PaperWorksService
{
    public class PaperWorkService : IPaperWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public PaperWorkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PaperWorkResponse>> GetAll()
        {

            var list = await _unitOfWork.Repository<PaperWork>().GetAll()
                                            .ProjectTo<PaperWorkResponse>(_mapper.ConfigurationProvider)
                                            .ToListAsync();
            return list;
        }

        public async Task<PaperWorkResponse> Get(Guid id)
        {
            try
            {
                PaperWork paperWork = null;
                paperWork = await _unitOfWork.Repository<PaperWork>().GetAll()
                     .AsNoTracking()
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (paperWork == null)
                {
                    throw new Exception("khong tim thay");
                }

                return _mapper.Map<PaperWork, PaperWorkResponse>(paperWork);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PaperWorkResponse> Create(PaperWorkRequest request)
        {
            // Set the UTC offset for UTC+7
            TimeSpan utcOffset = TimeSpan.FromHours(7);

            // Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Convert the UTC time to UTC+7
            DateTime localTime = utcNow + utcOffset;
            try
            {
                var paperWork = _mapper.Map<PaperWorkRequest, PaperWork>(request);
                paperWork.Id = Guid.NewGuid();
                paperWork.CreatedDate = localTime;
                await _unitOfWork.Repository<PaperWork>().InsertAsync(paperWork);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<PaperWork, PaperWorkResponse>(paperWork);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PaperWorkResponse> Delete(Guid id)
        {
            try
            {
                PaperWork paperWork = null;
                paperWork = _unitOfWork.Repository<PaperWork>()
                    .Find(p => p.Id == id);
                if (paperWork == null)
                {
                    throw new Exception("Bi trung id");
                }
                await _unitOfWork.Repository<PaperWork>().HardDeleteGuid(paperWork.Id);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<PaperWork, PaperWorkResponse>(paperWork);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PaperWorkResponse> Update(Guid id, PaperWorkRequest request)
        {
            // Set the UTC offset for UTC+7
            TimeSpan utcOffset = TimeSpan.FromHours(7);

            // Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Convert the UTC time to UTC+7
            DateTime localTime = utcNow + utcOffset;
            try
            {
                PaperWork paperWork = _unitOfWork.Repository<PaperWork>()
                            .Find(x => x.Id == id);
                if (paperWork == null)
                {
                    throw new Exception();
                }
                paperWork = _mapper.Map(request, paperWork);
                paperWork.UpdatedDate = localTime;

                await _unitOfWork.Repository<PaperWork>().UpdateDetached(paperWork);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<PaperWork, PaperWorkResponse>(paperWork);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
