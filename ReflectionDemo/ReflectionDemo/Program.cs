using System;
using System.Reflection;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionDemo.Customer");

            Console.WriteLine("Name : ");
            Console.WriteLine($"Fullname = {t.FullName}");
            Console.WriteLine($"Name = {t.Name}");
            Console.WriteLine($"Namespace = {t.Namespace}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Property Information");
            Console.WriteLine();
            PropertyInfo[] properties = t.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();


            Console.WriteLine("Constructor Information");
            ConstructorInfo[] constructors = t.GetConstructors();

            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
                ParameterInfo[] parameters = constructor.GetParameters();
                if (parameters != null)
                {
                    foreach (ParameterInfo param in parameters)
                    {
                        Console.WriteLine("\t" + param.ParameterType.Name + " " + param.Name);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Method Information");
            Console.WriteLine();
            MethodInfo[] methods = t.GetMethods();

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);

                ParameterInfo[] parameters = method.GetParameters();
                if (parameters != null)
                {
                    foreach (ParameterInfo param in parameters)
                    {
                        Console.WriteLine("\t" + param.ParameterType.Name + " " + param.Name);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Nested Type Information");
            Console.WriteLine();
            Type[] nestedTypes = t.GetNestedTypes();

            foreach (Type type in nestedTypes)
            {
                Console.WriteLine(type.BaseType.Name + " " + type.Name);
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Interfaces Information");
            Console.WriteLine();
            Type[] interfaces = t.GetInterfaces();

            foreach (Type type in interfaces)
            {
                Console.WriteLine(type.FullName);
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Calling  Methods");
            Console.WriteLine();

            Type t2 = Type.GetType("ReflectionDemo.Customer");
            object objCustomer = Activator.CreateInstance(t2, 10, "ReflectionDemo");
            MethodInfo methodInfo = t2.GetMethod("Display");
            object[] mParam = new object[1];
            mParam[0] = "This is a Reflection Demo !";
            methodInfo.Invoke(objCustomer, mParam);

            Console.ReadLine();
        }
    }

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
    public class MyClass
    {
    }

    public interface MyInterface
    {

    }

    public interface ICustomer
    {

    }
}
