﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Models;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace Service.AccountForumsService
{
    public class AccountForumService: IAccountForumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public AccountForumService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AccountForumResponse>> GetAll()
        {

            var list = await _unitOfWork.Repository<AccountForum>().GetAll()
                                            .ProjectTo<AccountForumResponse>(_mapper.ConfigurationProvider)
                                            .ToListAsync();
            return list;
        }
        public async Task<AccountForumResponse> Get(Guid id)
        {
            try
            {
                AccountForum accountForum = null;
                accountForum = await _unitOfWork.Repository<AccountForum>().GetAll()
                     .AsNoTracking()
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (accountForum == null)
                {
                    throw new Exception("khong tim thay");
                }

                return _mapper.Map<AccountForum, AccountForumResponse>(accountForum);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AccountForumResponse> Create(AccountForumRequest request)
        {
            // Set the UTC offset for UTC+7
            TimeSpan utcOffset = TimeSpan.FromHours(7);

            // Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Convert the UTC time to UTC+7
            DateTime localTime = utcNow + utcOffset;
            try
            {
                var accountforum = _mapper.Map<AccountForumRequest, AccountForum>(request);
                accountforum.Id = Guid.NewGuid();
                accountforum.MessagedDate = localTime;
                await _unitOfWork.Repository<AccountForum>().InsertAsync(accountforum);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<AccountForum, AccountForumResponse>(accountforum);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AccountForumResponse> Delete(Guid id)
        {
            try
            {
                AccountForum accountForum = null;
                accountForum = _unitOfWork.Repository<AccountForum>()
                    .Find(p => p.Id == id);
                if (accountForum == null)
                {
                    throw new Exception("Bi trung id");
                }
                await _unitOfWork.Repository<AccountForum>().HardDeleteGuid(accountForum.Id);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<AccountForum, AccountForumResponse>(accountForum);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountForumResponse> Update(Guid id, AccountForumRequest request)
        {
            try
            {
                AccountForum accountForum = _unitOfWork.Repository<AccountForum>()
                            .Find(x => x.Id == id);
                if (accountForum == null)
                {
                    throw new Exception();
                }
                accountForum = _mapper.Map(request, accountForum);

                await _unitOfWork.Repository<AccountForum>().UpdateDetached(accountForum);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<AccountForum, AccountForumResponse>(accountForum);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
