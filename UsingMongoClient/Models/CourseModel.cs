using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsingMongoClient.Models
{
public class CourseModel
{
    [BsonId]
    public string CourseId { get; set;}

    [BsonElement]
    public string CourseName { get; set; }

    [BsonElement]
    public string Teacher { get; set; }

    [BsonElement]
    public List<Student> Students { get; set; }
}

public class Student
{
    public int Id { get; set; }

    public string Name { get; set; }
}
}
