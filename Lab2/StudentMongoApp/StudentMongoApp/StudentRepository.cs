using MongoDB.Driver;

namespace StudentMongoApp
{
    public class StudentRepository
    {
        private readonly IMongoCollection<Student> students;

        public StudentRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("StudentDB");

            students = database.GetCollection<Student>("Students");
        }

        public List<Student> GetAll()
        {
            return students.Find(_ => true).ToList();
        }

        public void Add(Student student)
        {
            students.InsertOne(student);
        }

        public void Delete(string id)
        {
            students.DeleteOne(x => x.Id == id);
        }

        public Student FindById(string id)
        {
            return students.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Update(Student student)
        {
            students.ReplaceOne(x => x.Id == student.Id, student);
        }

        public List<Student> Search(string keyword)
        {
            return students.Find(x =>
                x.Name.Contains(keyword) ||
                x.Address.Contains(keyword) ||
                x.Grade.Contains(keyword)
            ).ToList();
        }
    }
}