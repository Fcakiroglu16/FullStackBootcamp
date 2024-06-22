// See https://aka.ms/new-console-template for more information

using System.Collections;
using Generic.App;

Console.WriteLine("Hello, World!");


//var cache = new Cache();
//cache.AddCache("userId", 23);
//cache.AddCache("productId", 10);
//cache.AddCache("email", "ahmet@outlook.com");

//Console.WriteLine($"userId:{cache.GetCache("userId")}");


var cacheGeneric = new CacheGeneric<string, int>();
cacheGeneric.AddCache("userId", 23);
cacheGeneric.AddCache("productId", 10);

Console.WriteLine($"userId:{cacheGeneric.GetCache("userId")}");


var cacheGeneric2 = new CacheGeneric<string, string>();
cacheGeneric2.AddCache("email", "ahmet@outlook.com");

Console.WriteLine($"userId:{cacheGeneric2.GetCache("userId")}");

//var methodExample = new MethodExample();
//Console.WriteLine(methodExample.CompareGeneric(7, 5));
//Console.WriteLine(methodExample.AddGeneric(5, 5));
//Console.WriteLine(methodExample.AddGeneric("ahmet", "mehmet"));
//Console.WriteLine(methodExample.AddGeneric(10.2, 10.5));