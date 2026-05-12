using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentApp
{
    public class StudentRepository
    {
        private readonly List<Student> students = new();

        private int nextId = 1;

        private readonly string filePath = "students.txt";

        public StudentRepository()
        {
            LoadFromFile();
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student Add(Student student)
        {
            student.Id = nextId++;

            students.Add(student);

            SaveToFile();

            return student;
        }

        public bool Delete(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                students.Remove(student);

                SaveToFile();

                return true;
            }

            return false;
        }

        public bool Update(Student updatedStudent)
        {
            var student = students.FirstOrDefault(x => x.Id == updatedStudent.Id);

            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.Email = updatedStudent.Email;
                student.Address = updatedStudent.Address;
                student.Age = updatedStudent.Age;
                student.Grade = updatedStudent.Grade;

                SaveToFile();

                return true;
            }

            return false;
        }

        public Student FindById(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        public List<Student> Search(string keyword)
        {
            return students.Where(x =>
                x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                x.Address.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                x.Grade.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        private void LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            foreach (var line in File.ReadAllLines(filePath))
            {
                var student = Student.FromFileString(line);

                students.Add(student);

                if (student.Id >= nextId)
                {
                    nextId = student.Id + 1;
                }
            }
        }

        private void SaveToFile()
        {
            File.WriteAllLines(filePath,
                students.Select(x => x.ToFileString()));
        }
    }
}