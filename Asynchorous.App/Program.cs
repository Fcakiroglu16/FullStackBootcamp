// See https://aka.ms/new-console-template for more information

using Asynchronous.App;

Console.WriteLine("Asynchronous Programming");


var multiThread = new MultiThreadExample();

Console.WriteLine("step 1");
multiThread.TaskExample("https://www.google.com");
Console.WriteLine("step 2");

Console.ReadKey();


//multiThread.ParallelExample();


//var sync = new SyncExample();
//Console.WriteLine("1.adım");
//await sync.RunAsync();
//Console.WriteLine("2.adım");

//var key = Console.ReadKey();