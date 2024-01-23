﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace Service.LessonsService
{
    public interface ILessonService
    {
        public Task<List<LessonResponse>> GetLessons();

        public Task<LessonResponse> Create(LessonRequest request);

        public Task<LessonResponse> Delete(Guid id);

        public Task<LessonResponse> Update(Guid id, LessonRequest request);
    }
}
