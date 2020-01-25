using System;

namespace BusinessLayer
{
    public class Customer : ICustomer
    {
        public MyClass d { get; set; }
        public MyInterface i { get; set; }
        public delegate void mydelegate(string data);

        public int id { get; set; }
        public string name { get; set; }

        public Customer()
        {
            Console.WriteLine("This is Default Constructor");
        }

        public Customer(int id, string name)
        {
            Console.WriteLine("This is Paramiterise Constructor");
            this.id = id;
            this.name = name;
        }

        public void Display(string data)
        {
            Console.WriteLine($"Id = {id} Name = {name}");
            Console.WriteLine(data);
        }
    }
}
