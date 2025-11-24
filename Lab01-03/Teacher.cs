using System;

namespace Lab01_03
{
    internal class Teacher : Person
    {
        private string address;

        public Teacher() { }

        public Teacher(string id, string fullname, string address)
            : base(id, fullname)
        {
            this.address = address;
        }

        public string Address { get => address; set => address = value; }

        public override void input()
        {
            base.input();

            Console.Write("Nhập địa chỉ: ");
            Address = Console.ReadLine();
        }

        public override void output()
        {
            base.output();
            Console.WriteLine($"Địa chỉ: {Address}");
        }
    }
}
