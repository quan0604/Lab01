using System;

namespace Lab01_03
{
    internal class Student : Person
    {
        private float averageScore;
        private string faculty;

        public Student() { }

        public Student(string id, string fullname, float averageScore, string faculty)
            : base(id, fullname)
        {
            this.averageScore = averageScore;
            this.faculty = faculty;
        }

        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public override void input()
        {
            base.input();

            // Nhập điểm TB có kiểm tra
            float score;
            do
            {
                Console.Write("Nhập điểm trung bình: ");
            }
            while (!float.TryParse(Console.ReadLine(), out score));

            AverageScore = score;

            Console.Write("Nhập khoa: ");
            Faculty = Console.ReadLine();
        }

        public override void output()
        {
            base.output();
            Console.WriteLine($"Điểm TB: {AverageScore} - Khoa: {Faculty}");
        }
    }
}
