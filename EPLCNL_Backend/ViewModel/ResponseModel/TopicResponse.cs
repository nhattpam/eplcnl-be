﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ResponseModel
{
    public class TopicResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? ClassLessonId { get; set; }
        public bool? IsActive { get; set; }
        public virtual ClassLessonResponse? ClassLesson { get; set; }
    }
}
