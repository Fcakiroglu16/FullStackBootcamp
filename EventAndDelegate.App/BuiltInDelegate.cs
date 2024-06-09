namespace EventAndDelegate.App
{
    internal class BuiltInDelegate
    {
        public BuiltInDelegate()
        {
            // void (parameter) => Action

            Action<int, int> action = (a, b) => Console.WriteLine(a + b);
            Action<int, int, string> action2 = (a, b, c) => Console.WriteLine(a + b);
            Action<int, int> action1 = ActionMethod1;

            // bool (parameter) => Predicate
            Predicate<string> predicate1 = (a) => a == "asp.netcore";
            Predicate<string> predicate2 = PredicateMethod1;

            // double   string,double,double
            // Dynamic ( Parameter)
            Func<double, double, int> func1 = (a, b) => (int)(a + b);
        }


        void ActionMethod1(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        bool PredicateMethod1(string name)
        {
            return name == "Asp.Net Core";
        }
    }
}