using System.Collections;
using System.Data;
using System.Text;

namespace CollectionsAndArrays.App
{
    internal class Program
    {
        static void BoxingAndUnBoxing()
        {
            var objects = new object[3];
            objects[0] = 1;
            objects[1] = "Hello";
            objects[2] = true;
            String value5 = (string)objects[1];

            //boxing/unboxing
            // Boxing is the process of converting a value type to the type object or to any interface type implemented by this value type.
            // Unboxing extracts the value type from the object.

            // byte, short, int, long, float, double, decimal

            int i = 10;


            //boxing
            Object value = i;
            //unboxing
            int j = (int)value;
        }


        static void method1(object value)
        {
            if (value is int i)
            {
                var tax = i * 1.20;
            }

            if (value is string val)
            {
            }
        }

        static void Main(string[] args)
        {
            // Arrays

            // Create an array of integers
            var numbers = new int[5];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3;
            numbers[3] = 4;
            numbers[4] = 5;

            // Create an array of strings
            var names = new string[3];
            names[0] = "John";
            names[1] = "Jack";
            names[2] = "Jill";

            // Create an array of objects
            var objects = new object[3];
            objects[0] = 1;
            objects[1] = "Hello";
            objects[2] = true;


            var numbers2 = new[] { 1, 2, 3, 4, 5, 6 };

            var names2 = new[] { "ahmet", "mehmet" };

            var objects2 = new object[] { 1, "Hello", true };


            // ADDING ELEMENTS TO AN ARRAY
            // Create an array of integers
            var numbers3 = new int[5];

            var matrix = new int[,] { { 1, 2 }, { 4, 5 } };


            foreach (var item in numbers2)
            {
            }

            // Collections
            // List<T>

            #region List

            var names4 = new List<string>();
            // 100 / full table scan
            // LinQ to Collection/Array
            names4.Add("John");
            names4.Add("Jack");
            names4.Remove("John");

            names4.ForEach(x => { });

            names4.Where(x => x == "John");

            names4.Remove(names4.First());
            foreach (var item in names4)
            {
            }

            #endregion

            #region HashSet

            var names5 = new HashSet<string>();

            names5.Add("John");
            names5.Add("Jack");
            names5.Add("John");
            names5.Add("ahmet");
            foreach (var item in names5)
            {
            }

            #endregion

            #region Dictionary

            var cities = new Dictionary<int, string>();


            cities.Add(34, "istanbul");
            cities.Add(14, "bolu");

            foreach (var item in cities)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

            #endregion

            #region HashTable

            var cities2 = new Hashtable();

            cities2.Add(34, "istanbul");
            cities2.Add(14, "bolu");

            #endregion

            #region LinkedList

            LinkedList<string> names10 = new LinkedList<string>();

            names10.AddLast("John");
            names10.AddLast("Jack");
            names10.AddFirst("ahmet");
            names10.AddAfter(new LinkedListNode<string>("Jack"), "Mehmet");


            names10.AddLast("John");

            var jack = names10.AddLast("Jack");
            names10.AddLast("ahmet");
            names10.AddLast("hasan");
            names10.AddAfter(jack, "Mehmet");

            var ahmet = names10.Find("ahmet");
            names10.AddAfter(ahmet!, "emre");
            foreach (var item in names10)
            {
                Console.WriteLine(item);
            }

            #endregion


            #region Queue

            //FIFO => first in first out
            Queue<int> myQueue = new Queue<int>();

            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);

            var queueFirstItem = myQueue.Dequeue();


            Console.WriteLine($"first item:{queueFirstItem}");
            // queue foreach
            foreach (var item in myQueue)
            {
                Console.WriteLine(item);
            }

            #endregion


            #region Stack

            // LIFO => last in first out
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            var pop = stack.Pop();

            #endregion


            Console.WriteLine("Hello, World!");
        }
    }
}