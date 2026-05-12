namespace StudentMongoApp
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
                Console.WriteLine("1. Danh sách");
                Console.WriteLine("2. Thêm");
                Console.WriteLine("3. Sửa");
                Console.WriteLine("4. Xóa");
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
                }

                Console.WriteLine("\nEnter để tiếp tục...");
                Console.ReadLine();
            }
        }

        private void ShowStudents()
        {
            var students = service.GetStudents();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            if (students.Count == 0)
            {
                Console.WriteLine("Không có dữ liệu");
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

            Console.WriteLine("Đã thêm");
        }

        private void EditStudent()
        {
            Console.Write("Nhập ID: ");

            string id = Console.ReadLine();

            var student = service.FindStudent(id);

            if (student == null)
            {
                Console.WriteLine("Không tìm thấy");
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

            Console.WriteLine("Đã sửa");
        }

        private void DeleteStudent()
        {
            Console.Write("Nhập ID: ");

            string id = Console.ReadLine();

            service.DeleteStudent(id);

            Console.WriteLine("Đã xóa");
        }

        private void SearchStudent()
        {
            Console.Write("Nhập từ khóa: ");

            string keyword = Console.ReadLine();

            var students = service.SearchStudents(keyword);

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