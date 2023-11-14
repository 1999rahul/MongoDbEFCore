using MongoDB.Bson;

namespace EfCoreMongoDB
{
    public class Student
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get;set; }
    }
}
