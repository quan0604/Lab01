using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            List<Teacher> teacherList = new List<Teacher>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Thêm giáo viên");
                Console.WriteLine("3. Xuất danh sách sinh viên");
                Console.WriteLine("4. Xuất danh sách giáo viên");
                Console.WriteLine("5. Số lượng từng danh sách");
                Console.WriteLine("6. Danh sách sinh viên khoa CNTT");
                Console.WriteLine("8. Sinh viên DTB cao nhất khoa CNTT");
                Console.WriteLine("9. Thống kê xếp loại sinh viên");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;

                    case "2":
                        AddTeacher(teacherList);
                        break;

                    case "3":
                        DisplayStudents(studentList);
                        break;

                    case "4":
                        DisplayTeachers(teacherList);
                        break;

                    case "5":
                        DisplayCounts(studentList, teacherList);
                        break;

                    case "6":
                        DisplayCNTTStudents(studentList);
                        break;
                    case "8":
                        DisplayTopCNTTStudents(studentList);
                        break;

                    case "9":
                        DisplayStudentClassification(studentList);
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("❌ Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }

        // 1. Thêm sinh viên
        static void AddStudent(List<Student> list)
        {
            Console.WriteLine("=== Thêm sinh viên ===");
            Student s = new Student();
            s.input();
            list.Add(s);
            Console.WriteLine("✔ Đã thêm sinh viên!");
        }

        // 2. Thêm giáo viên
        static void AddTeacher(List<Teacher> list)
        {
            Console.WriteLine("=== Thêm giáo viên ===");
            Teacher t = new Teacher();
            t.input();
            list.Add(t);
            Console.WriteLine("✔ Đã thêm giáo viên!");
        }

        // 3. Xuất danh sách sinh viên
        static void DisplayStudents(List<Student> list)
        {
            Console.WriteLine("=== Danh sách sinh viên ===");
            if (list.Count == 0)
            {
                Console.WriteLine("Không có sinh viên nào!");
                return;
            }

            foreach (var s in list)
                s.output();
        }

        // 4. Xuất danh sách giáo viên
        static void DisplayTeachers(List<Teacher> list)
        {
            Console.WriteLine("=== Danh sách giáo viên ===");
            if (list.Count == 0)
            {
                Console.WriteLine("Không có giáo viên nào!");
                return;
            }

            foreach (var t in list)
                t.output();
        }

        // 5. Số lượng sinh viên & giáo viên
        static void DisplayCounts(List<Student> students, List<Teacher> teachers)
        {
            Console.WriteLine("=== Số lượng từng danh sách ===");
            Console.WriteLine("Tổng số sinh viên: " + students.Count);
            Console.WriteLine("Tổng số giáo viên: " + teachers.Count);
        }

        // 6. Sinh viên khoa CNTT
        static void DisplayCNTTStudents(List<Student> list)
        {
            Console.WriteLine("=== Sinh viên khoa CNTT ===");

            var result = list.Where(s =>
                s.Faculty.Equals("CNTT", StringComparison.OrdinalIgnoreCase)).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("Không có sinh viên CNTT!");
                return;
            }

            foreach (var s in result)
                s.output();
        }

        // 7. Giáo viên có địa chỉ "Quận 9"


        // 8. Sinh viên DTB cao nhất + khoa CNTT
        static void DisplayTopCNTTStudents(List<Student> list)
        {
            Console.WriteLine("=== SV điểm cao nhất khoa CNTT ===");

            var cntt = list.Where(s =>
                s.Faculty.Equals("CNTT", StringComparison.OrdinalIgnoreCase)).ToList();

            if (cntt.Count == 0)
            {
                Console.WriteLine("Không có sinh viên CNTT!");
                return;
            }

            float maxScore = cntt.Max(s => s.AverageScore);

            var result = cntt.Where(s => s.AverageScore == maxScore).ToList();

            Console.WriteLine("→ Điểm cao nhất: " + maxScore);
            foreach (var s in result)
                s.output();
        }

        // 9. Thống kê xếp loại sinh viên
        static void DisplayStudentClassification(List<Student> list)
        {
            Console.WriteLine("=== Thống kê xếp loại sinh viên ===");

            int xs = list.Count(s => s.AverageScore >= 9);
            int gioi = list.Count(s => s.AverageScore >= 8 && s.AverageScore < 9);
            int kha = list.Count(s => s.AverageScore >= 7 && s.AverageScore < 8);
            int tb = list.Count(s => s.AverageScore >= 5 && s.AverageScore < 7);
            int yeu = list.Count(s => s.AverageScore >= 4 && s.AverageScore < 5);
            int kem = list.Count(s => s.AverageScore < 4);

            Console.WriteLine($"Xuất sắc (>=9): {xs}");
            Console.WriteLine($"Giỏi (8–<9): {gioi}");
            Console.WriteLine($"Khá (7–<8): {kha}");
            Console.WriteLine($"Trung bình (5–<7): {tb}");
            Console.WriteLine($"Yếu (4–<5): {yeu}");
            Console.WriteLine($"Kém (<4): {kem}");
        }
    }
}
