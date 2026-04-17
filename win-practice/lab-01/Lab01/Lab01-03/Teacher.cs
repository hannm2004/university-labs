using System;

namespace Lab01_03
{
    class Teacher : Person
    {
        public string Address { get; set; }

        public Teacher() : base() { }

        public Teacher(string id, string fullName, string address) : base(id, fullName)
        {
            Address = address;
        }

        public override void Input()
        {
            base.Input(); // Nhập ID và FullName
            Console.Write("Nhập địa chỉ: ");
            Address = Console.ReadLine();
        }

        public override void Show()
        {
            base.Show(); // Xuất ID và FullName
            Console.WriteLine(", Địa chỉ: {0}", Address);
        }
    }
}
