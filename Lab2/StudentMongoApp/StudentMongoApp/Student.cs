using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentMongoApp
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public string Grade { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Name} | {Email} | {Address} | {Age} | {Grade}";
        }
    }
}