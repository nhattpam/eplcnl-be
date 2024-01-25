﻿using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace Service.AccountsService
{
    public interface IAccountService
    {
        Task<AccountResponse> Login(LoginMem loginMem);
        Task<List<AccountResponse>> GetAll();
        public Task<AccountResponse> Get(Guid id);

        Task<AccountResponse> Create(AccountRequest request);
        Task<AccountResponse> Update(Guid id, AccountRequest request);
        Task<AccountResponse> Delete(Guid id);
    }
}