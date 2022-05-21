using System;
using System.Collections.Generic;
using System.Text;

namespace UsingMongoClient.Models
{
    public class UpdateCourseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string CourseId { get; set; }
        /// <summary>
        /// 更新的課程名稱
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 更新的教師
        /// </summary>
        public string Teacher { get; set; }
    }
}
