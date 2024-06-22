// See https://aka.ms/new-console-template for more information

using Extensions.App;

Console.WriteLine("Extension Methods");

List<int> numbers = new List<int>() { 1, 30, 2, 6, 7, 10 };
LinkedList<int> numbers2 = new LinkedList<int>();

numbers2.AddLast(10);
numbers2.AddLast(20);
numbers2.AddLast(30);
numbers2.AddLast(5);

numbers.
foreach (var number in numbers2.GetRandomList())
{
    Console.WriteLine(number);
}

Console.WriteLine("-------------");
foreach (var number in numbers.GetRandomList())
{
    Console.WriteLine(number);
}


//var number = 6;


//var url = "https://www.abc.com/products/xyz";
//url.ShortUrl();

//Console.WriteLine($"Is Event :{number.IsEven()}");
//Console.WriteLine($"Is Event :{NumberHelpers.IsEven(number)}");


//var name = "ahmet";

//if (name.IsNullOrEmptyOrWhiteSpace())
//{
//}