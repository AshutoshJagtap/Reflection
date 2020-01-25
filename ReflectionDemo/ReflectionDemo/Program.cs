using System;
using System.Linq;
using System.Reflection;
namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //If you want use reflection on other project Assembly.
            //you must need to add reference of this Assembly in current project
            //or if you don't want to add reference then need to provide full path of Assembly
            //e.g Assembly.LoadFrom("../../../BusinessLayer/bin/Debug/BusinessLayer.dll")

            Assembly assembly = Assembly.LoadFrom("BusinessLayer.dll");
            Type type= assembly.GetTypes().Where(x=>x.Name== "Customer").FirstOrDefault();

            //If you want use reflection on current executing Assembly.
            //Type type =Type.GetType("ReflectionDemo.Customer");

            Console.WriteLine("Assembly Information : ");
            Console.WriteLine($"Fullname = {type.FullName}");
            Console.WriteLine($"Name = {type.Name}");
            Console.WriteLine($"Namespace = {type.Namespace}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Property Information");
            Console.WriteLine();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Constructor Information");
            Console.WriteLine();
            ConstructorInfo[] constructors = type.GetConstructors();

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
            MethodInfo[] methods = type.GetMethods();

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
            Type[] nestedTypes = type.GetNestedTypes();

            foreach (Type nestedType in nestedTypes)
            {
                Console.WriteLine(nestedType.BaseType.Name + " " + nestedType.Name);
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Interfaces Information");
            Console.WriteLine();
            Type[] interfaces = type.GetInterfaces();

            foreach (Type Interface in interfaces)
            {
                Console.WriteLine(Interface.FullName);
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Calling  Constructor and Methods");
            Console.WriteLine();

            object objCustomer = Activator.CreateInstance(type, 10, "ReflectionDemo");
            MethodInfo methodInfo = type.GetMethod("Display");
            object[] mParam = new object[1];
            mParam[0] = "This is a Reflection Demo !";
            methodInfo.Invoke(objCustomer, mParam);

            Console.ReadLine();
        }
    }
}
