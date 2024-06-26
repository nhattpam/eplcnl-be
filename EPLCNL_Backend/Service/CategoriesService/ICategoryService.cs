﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace Service.CategoriesService
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponse>> GetAll();

        public Task<CategoryResponse> Get(Guid id);

        public Task<List<CourseResponse>> GetAllCoursesByCategory(Guid id);


        public Task<CategoryResponse> Create(CategoryRequest request);

        public Task<CategoryResponse> Delete(Guid id);

        public Task<CategoryResponse> Update(Guid id, CategoryRequest request);
    }
}
