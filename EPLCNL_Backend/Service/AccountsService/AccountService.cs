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

        public async Task<AccountResponse> Get(Guid? id)
        {
            try
            {
                Account account = null;
                account = await _unitOfWork.Repository<Account>().GetAll()
                     .AsNoTracking()
                        .Include(a => a.Role)
                        //.Include(a => a.Center)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (account == null)
                {
                    throw new Exception("khong tim thay");
                }

                return _mapper.Map<Account, AccountResponse>(account);
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
            // Validate input parameters
            if (accc == null || string.IsNullOrEmpty(accc.Email) || string.IsNullOrEmpty(accc.Password))
            {
                // Handle invalid input, e.g., log an error or return a meaningful response
                return null;
            }

            // Retrieve the account based on email and password
            Account account = _unitOfWork.Repository<Account>()
                .Find(x => x.Email == accc.Email && x.Password == accc.Password);

            // Check if the account is null
            if (account == null)
            {
                // Handle the case where no account is found, e.g., log an error or return a meaningful response
                return null;
            }

            // Check if Email or Password is null, and handle the case appropriately
            if (string.IsNullOrEmpty(account.Email) || string.IsNullOrEmpty(account.Password))
            {
                // Handle the case where Email or Password is null, e.g., log an error or return a meaningful response
                return null;
            }

            // Map the account to the response object
            return _mapper.Map<Account, AccountResponse>(account);
        }

    }
}
