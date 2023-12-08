using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module15.Practice
{
    class MyClass
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public MyClass()
        {
       
        }

        public MyClass(int value)
        {
            MyProperty1 = value;
        }

        public void MyMethod1()
        {
            Console.WriteLine("MyMethod1 called");
        }

        public string MyMethod2(int number)
        {
            return $"MyMethod2 called with {number}";
        }
        private void PrivateMethod()
        {
            Console.WriteLine("PrivateMethod called");
        }
    }

    class Program
    {
        static void Main()
        {
            Type myClassType = typeof(MyClass);

            Console.WriteLine($"Class name: {myClassType.Name}");

            ConstructorInfo[] constructors = myClassType.GetConstructors();
            Console.WriteLine("\nConstructor list:");
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine($"{constructor} (access modifier: {constructor.Attributes})");
            }

            Console.WriteLine("\nList of fields and properties:");
            foreach (FieldInfo field in myClassType.GetFields())
            {
                Console.WriteLine($"{field.FieldType.Name} {field.Name} (access modifier: {field.Attributes})");
            }

            foreach (PropertyInfo property in myClassType.GetProperties())
            {
                Console.WriteLine($"{property.PropertyType.Name} {property.Name} (access modifier: {property.Attributes})");
            }

            Console.WriteLine("\nmethod list:");
            foreach (MethodInfo method in myClassType.GetMethods())
            {
                Console.WriteLine($"{method.ReturnType.Name} {method.Name} (access modifier: {method.Attributes})");
            }

       
            object myObject = Activator.CreateInstance(myClassType);

            myClassType.GetProperty("MyProperty1").SetValue(myObject, 42);
            myClassType.GetProperty("MyProperty2").SetValue(myObject, "Hello, Reflection!");

            myClassType.GetMethod("MyMethod1").Invoke(myObject, null);
            object result = myClassType.GetMethod("MyMethod2").Invoke(myObject, new object[] { 10 });
            Console.WriteLine($"transfer MyMethod2 result: {result}");

            MethodInfo privateMethod = myClassType.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privateMethod.Invoke(myObject, null);
        }
    }
}
