using System;

namespace Lab01_03
{
    class Person
    {
        public string ID { get; set; }
        public string FullName { get; set; }

        public Person() { }

        public Person(string id, string fullName)
        {
            ID = id;
            FullName = fullName;
        }

        public virtual void Input()
        {
            Console.Write("Nhập mã số: ");
            ID = Console.ReadLine();
            Console.Write("Nhập họ và tên: ");
            FullName = Console.ReadLine();
        }

        public virtual void Show()
        {
            Console.Write("Mã số: {0}, Họ Tên: {1}", ID, FullName);
        }
    }
}
