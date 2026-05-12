using System.Collections.Generic;

namespace StudentApp
{
    public class StudentService
    {
        private readonly StudentRepository repo = new();

        public List<Student> GetStudents()
        {
            return repo.GetAll();
        }

        public Student AddStudent(Student student)
        {
            return repo.Add(student);
        }

        public bool DeleteStudent(int id)
        {
            return repo.Delete(id);
        }

        public bool UpdateStudent(Student student)
        {
            return repo.Update(student);
        }

        public Student FindStudent(int id)
        {
            return repo.FindById(id);
        }

        public List<Student> SearchStudents(string keyword)
        {
            return repo.Search(keyword);
        }
    }
}