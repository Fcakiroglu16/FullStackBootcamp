using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.App
{
    // camelCase ( parametre,variable)
    // PascalCase ( Method Name,Class Name)
    //snake_case
    //kebab-case


    public class A
    {
    }


    internal class MethodExample
    {
        public T AddGeneric<T>(T a, T b) where T : struct
        {
            return (dynamic)a! + (dynamic)b!;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }

        public bool Equals<T>(T a, T b)
        {
            return a!.Equals(b);
        }


        public bool CompareGeneric<T>(T a, T b) where T : struct, IComparable<T>
        {
            return a.CompareTo(b) > 0;
        }

        public T CompareGeneric2<T>(T a, T b) where T : struct, IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public int CompareGeneric3<T>(T a, T b) where T : struct, IComparable<T>
        {
            return a.CompareTo(b);
        }

        public bool Compare(int a, int b)
        {
            return a > b;
        }

        public bool Compare(double a, double b)
        {
            return a > b;
        }
    }
}