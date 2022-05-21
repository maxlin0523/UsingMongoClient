using System;
using System.Collections.Generic;
using System.Text;

namespace UsingMongoClient.Models
{
    public class CourseMongoDatabaseSetting
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 資料庫
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// Collection
        /// </summary>
        public string Collection { get; set; }
    }
}
