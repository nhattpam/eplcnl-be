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

namespace Service.AccountsService
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AccountResponse>> GetAll()
        {

            var list = await _unitOfWork.Repository<Account>().GetAll()
                                            .ProjectTo<AccountResponse>(_mapper.ConfigurationProvider)
                                            .ToListAsync();
            return list;
        }

        public async Task<AccountResponse> Get(Guid id)
        {
            try
            {
                Account center = null;
                center = await _unitOfWork.Repository<Account>().GetAll()
                     .AsNoTracking()
                        .Include(a => a.Role)
                        //.Include(a => a.Center)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (center == null)
                {
                    throw new Exception("khong tim thay");
                }

                return _mapper.Map<Account, AccountResponse>(center);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AccountResponse> Create(AccountRequest request)
        {
            // Set the UTC offset for UTC+7
            TimeSpan utcOffset = TimeSpan.FromHours(7);

            // Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Convert the UTC time to UTC+7
            DateTime localTime = utcNow + utcOffset;
            try
            {
                var account = _mapper.Map<AccountRequest, Account>(request);
                account.Id = Guid.NewGuid();
                account.CreatedDate = localTime;
                account.IsDeleted = false;
                await _unitOfWork.Repository<Account>().InsertAsync(account);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Account, AccountResponse>(account);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AccountResponse> Delete(Guid id)
        {
            try
            {
                Account account = null;
                account = _unitOfWork.Repository<Account>()
                    .Find(p => p.Id == id);
                if (account == null)
                {
                    throw new Exception("Id is not existed");
                }
                await _unitOfWork.Repository<Account>().HardDeleteGuid(account.Id);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<Account, AccountResponse>(account);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountResponse> Update(Guid id, AccountRequest request)
        {
            // Set the UTC offset for UTC+7
            TimeSpan utcOffset = TimeSpan.FromHours(7);

            // Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Convert the UTC time to UTC+7
            DateTime localTime = utcNow + utcOffset;
            try
            {
                Account account = _unitOfWork.Repository<Account>()
                            .Find(x => x.Id == id);
                if (account == null)
                {
                    throw new Exception();
                }
                account = _mapper.Map(request, account);
                account.UpdatedDate = localTime;

                await _unitOfWork.Repository<Account>().UpdateDetached(account);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Account, AccountResponse>(account);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountResponse> Login(LoginMem accc)
        {
            { 
                Account account = _unitOfWork.Repository<Account>()
                           .Find(x => x.Email.Equals(accc.Email) && x.Password.Equals(accc.Password));
                if(account == null)
                {
                    return null;
                }
                return _mapper.Map<Account, AccountResponse>(account);
            }

        }
    }
}
