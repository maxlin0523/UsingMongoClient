using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsingMongoClient.Models;

namespace UsingMongoClient
{
    public class MongoRepository
    {
        private readonly IMongoCollection<CourseModel> _collection;

        public MongoRepository(CourseMongoDatabaseSetting setting)
        {
            MongoClient client = new MongoClient(setting.ConnectionString);

            IMongoDatabase database = client.GetDatabase(setting.Database);

            _collection = database.GetCollection<CourseModel>(setting.Collection);
        }

        /// <summary>
        /// 建立課程
        /// </summary>
        public async Task<bool> CreateCourse(CourseModel model)
        {
            await _collection.InsertOneAsync(model);
            return true;
        }

        /// <summary>
        /// 更新課程
        /// </summary>
        public async Task<bool> UpdateCourse(UpdateCourseModel model)
        {
            var update = new UpdateDefinitionBuilder<CourseModel>()
                .Set(x => x.Teacher, model.Teacher)
                .Set(x => x.CourseName, model.CourseName);

            await _collection.UpdateOneAsync(x => x.CourseId == model.CourseId, update);
            return true;
        }

        /// <summary>
        /// 取得一個課程
        /// </summary>
        public async Task<CourseModel> GetCourse(string courseId)
        {
            var result = await _collection.Find(x => x.CourseId == courseId).FirstOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// 取得全部課程
        /// </summary>
        public async Task<List<CourseModel>> GetAllCourse()
        {
            var result = await _collection.Find(_ => true).ToListAsync();
            return result;
        }

        /// <summary>
        /// 刪除課程
        /// </summary>
        public async Task<bool> DeleteCourse(string courseId)
        {
            await _collection.DeleteOneAsync(x => x.CourseId == courseId);
            return true;
        }
    }
}
