using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Danh sách sinh viên khoa CNTT");
                Console.WriteLine("4. Sinh viên có điểm TB >= 5");
                Console.WriteLine("5. Sắp xếp theo điểm trung bình tăng dần");
                Console.WriteLine("6. SV khoa CNTT và có DTB >= 5");
                Console.WriteLine("7. Sinh viên DTB cao nhất thuộc khoa CNTT");
                Console.WriteLine("8. Thống kê số lượng xếp loại");
                Console.WriteLine("0. Thoát");

                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(studentList); break;
                    case "2": DisplayStudentList(studentList); break;
                    case "3": DisplayStudentsByFaculty(studentList, "CNTT"); break;
                    case "4": DisplayStudentWithHighAverageScore(studentList, 5); break;
                    case "5": DisplayStudentByAverageScore(studentList); break;
                    case "6": DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5); break;
                    case "7": DisplayStudentsTopScoreCNTT(studentList); break;
                    case "8": DisplayStudentClassification(studentList); break;

                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;

                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ.");
                        break;
                }
            }
        }

        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("\n=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("→ Thêm sinh viên thành công!");
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng!");
                return;
            }

            Console.WriteLine("\n=== Danh sách sinh viên ===");
            foreach (Student student in studentList)
                student.Show();
        }

        // 3 - DS sinh viên khoa CNTT
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            var students = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine("\n=== Sinh viên thuộc khoa {0} ===", faculty);
            DisplayStudentList(students);
        }

        // 4 - Sinh viên có điểm TB >= minDTB
        static void DisplayStudentWithHighAverageScore(List<Student> studentList, float minDTB)
        {
            var students = studentList
                .Where(s => s.AverageScore >= minDTB)
                .ToList();

            Console.WriteLine("\n=== Sinh viên có điểm TB >= {0} ===", minDTB);
            DisplayStudentList(students);
        }

        // 5 - Sắp xếp tăng theo điểm TB
        static void DisplayStudentByAverageScore(List<Student> studentList)
        {
            var sorted = studentList
                .OrderBy(s => s.AverageScore)
                .ToList();

            Console.WriteLine("\n=== Danh sách sắp xếp theo điểm TB tăng dần ===");
            DisplayStudentList(sorted);
        }

        // 6 - SV khoa CNTT và DTB >= minDTB
        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            var students = studentList
                .Where(s => s.AverageScore >= minDTB &&
                            s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine("\n=== SV khoa {0} có DTB >= {1} ===", faculty, minDTB);
            DisplayStudentList(students);
        }

        // 7 - Sinh viên có DTB cao nhất và thuộc khoa CNTT
        static void DisplayStudentsTopScoreCNTT(List<Student> studentList)
        {
            var cnttStudents = studentList
                .Where(s => s.Faculty.Equals("CNTT", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (cnttStudents.Count == 0)
            {
                Console.WriteLine("Không có sinh viên khoa CNTT.");
                return;
            }

            float maxScore = cnttStudents.Max(s => s.AverageScore);

            var topStudents = cnttStudents
                .Where(s => s.AverageScore == maxScore)
                .ToList();

            Console.WriteLine("\n=== SV khoa CNTT có điểm cao nhất ({0}) ===", maxScore);
            DisplayStudentList(topStudents);
        }

        // 8 - Thống kê số lượng từng xếp loại
        static void DisplayStudentClassification(List<Student> studentList)
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng!");
                return;
            }

            Console.WriteLine("\n=== Thống kê xếp loại sinh viên ===");

            int xuatSac = studentList.Count(s => s.AverageScore >= 9);
            int gioi = studentList.Count(s => s.AverageScore >= 8 && s.AverageScore < 9);
            int kha = studentList.Count(s => s.AverageScore >= 7 && s.AverageScore < 8);
            int trungBinh = studentList.Count(s => s.AverageScore >= 5 && s.AverageScore < 7);
            int yeu = studentList.Count(s => s.AverageScore >= 4 && s.AverageScore < 5);
            int kem = studentList.Count(s => s.AverageScore < 4);

            Console.WriteLine("Xuất sắc (9 → 10): " + xuatSac);
            Console.WriteLine("Giỏi (8 → <9): " + gioi);
            Console.WriteLine("Khá (7 → <8): " + kha);
            Console.WriteLine("Trung bình (5 → <7): " + trungBinh);
            Console.WriteLine("Yếu (4 → <5): " + yeu);
            Console.WriteLine("Kém (<4): " + kem);
        }
    }
}
