﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace Service.StaffsService
{
    public interface IStaffService
    {
        public Task<List<StaffResponse>> GetAll();

        public Task<StaffResponse> Create(StaffRequest request);

        public Task<StaffResponse> Delete(Guid id);

        public Task<StaffResponse> Update(Guid id, StaffRequest request);
    }
}