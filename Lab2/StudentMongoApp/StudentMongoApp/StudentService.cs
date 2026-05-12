namespace StudentMongoApp
{
    public class StudentService
    {
        private readonly StudentRepository repository = new();

        public List<Student> GetStudents()
        {
            return repository.GetAll();
        }

        public void AddStudent(Student student)
        {
            repository.Add(student);
        }

        public void DeleteStudent(string id)
        {
            repository.Delete(id);
        }

        public Student FindStudent(string id)
        {
            return repository.FindById(id);
        }

        public void UpdateStudent(Student student)
        {
            repository.Update(student);
        }

        public List<Student> SearchStudents(string keyword)
        {
            return repository.Search(keyword);
        }
    }
}