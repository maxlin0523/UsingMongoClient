using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsingMongoClient.Models;

namespace UsingMongoClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var setting = new CourseMongoDatabaseSetting
            {
                ConnectionString = "mongodb://localhost:27017",
                Database = "Sample",
                Collection = "Course"
            };

            // 建立 Repo 實體，並注入 setting
            var repository = new MongoRepository(setting);

            // 新增課程
            var createResult = await repository.CreateCourse(new CourseModel
            {
                CourseId = "123",
                CourseName = "英文",
                Teacher = "Amy",
                Students = new List<Student>
        {
            new Student { Id = 1, Name = "Bob" },
        }
            });

            // 更新課程教師(Teacher) & 課程名稱(CourseName)
            var updateResult = await repository.UpdateCourse(new UpdateCourseModel
            {
                CourseId = "123",
                CourseName = "國文",
                Teacher = "Andy"
            });

            // 取得課程
            var course = await repository.GetCourse("123");

            // 取得所有課程
            var courses = await repository.GetAllCourse();

            // 刪除課程
            var deleteResult = await repository.DeleteCourse("123");
        }
    }
}
