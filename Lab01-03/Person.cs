using System;

namespace Lab01_03
{
    internal class Person
    {
        private string id;
        private string fullname;

        public Person() { }
        public Person(string id, string fullname)
        {
            this.id = id;
            this.fullname = fullname;
        }

        public string Id { get => id; set => id = value; }
        public string Fullname { get => fullname; set => fullname = value; }

        public virtual void input()
        {
            Console.Write("Nhập mã: ");
            Id = Console.ReadLine();

            Console.Write("Nhập họ và tên: ");
            Fullname = Console.ReadLine();
        }

        public virtual void output()
        {
            Console.WriteLine($"ID: {Id} - Name: {Fullname}");
        }
    }
}
