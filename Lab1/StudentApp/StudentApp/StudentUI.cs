using System;

namespace StudentApp
{
    public class StudentUI
    {
        private readonly StudentService service = new();

        public void Run()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== QUẢN LÝ SINH VIÊN =====");
                Console.WriteLine("1. Hiển thị danh sách");
                Console.WriteLine("2. Thêm sinh viên");
                Console.WriteLine("3. Sửa sinh viên");
                Console.WriteLine("4. Xóa sinh viên");
                Console.WriteLine("5. Tìm kiếm");
                Console.WriteLine("0. Thoát");

                Console.Write("Chọn: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowStudents();
                        break;

                    case "2":
                        AddStudent();
                        break;

                    case "3":
                        EditStudent();
                        break;

                    case "4":
                        DeleteStudent();
                        break;

                    case "5":
                        SearchStudent();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }

                Console.WriteLine("\nNhấn Enter để tiếp tục...");
                Console.ReadLine();
            }
        }

        private void ShowStudents()
        {
            var students = service.GetStudents();

            Console.WriteLine("\n===== DANH SÁCH SINH VIÊN =====");

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            if (students.Count == 0)
            {
                Console.WriteLine("Chưa có sinh viên nào");
            }
        }

        private void AddStudent()
        {
            Student student = new Student();

            Console.Write("Tên: ");
            student.Name = Console.ReadLine();

            Console.Write("Email: ");
            student.Email = Console.ReadLine();

            Console.Write("Địa chỉ: ");
            student.Address = Console.ReadLine();

            Console.Write("Tuổi: ");
            student.Age = int.Parse(Console.ReadLine());

            Console.Write("Lớp: ");
            student.Grade = Console.ReadLine();

            service.AddStudent(student);

            Console.WriteLine("Thêm thành công");
        }

        private void EditStudent()
        {
            Console.Write("Nhập ID cần sửa: ");

            int id = int.Parse(Console.ReadLine());

            var student = service.FindStudent(id);

            if (student == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên");
                return;
            }

            Console.Write("Tên mới: ");
            student.Name = Console.ReadLine();

            Console.Write("Email mới: ");
            student.Email = Console.ReadLine();

            Console.Write("Địa chỉ mới: ");
            student.Address = Console.ReadLine();

            Console.Write("Tuổi mới: ");
            student.Age = int.Parse(Console.ReadLine());

            Console.Write("Lớp mới: ");
            student.Grade = Console.ReadLine();

            service.UpdateStudent(student);

            Console.WriteLine("Sửa thành công");
        }

        private void DeleteStudent()
        {
            Console.Write("Nhập ID cần xóa: ");

            int id = int.Parse(Console.ReadLine());

            if (service.DeleteStudent(id))
            {
                Console.WriteLine("Xóa thành công");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên");
            }
        }

        private void SearchStudent()
        {
            Console.Write("Nhập từ khóa: ");

            string keyword = Console.ReadLine();

            var students = service.SearchStudents(keyword);

            Console.WriteLine("\n===== KẾT QUẢ TÌM KIẾM =====");

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            if (students.Count == 0)
            {
                Console.WriteLine("Không tìm thấy");
            }
        }
    }
}