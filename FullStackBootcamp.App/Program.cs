// See https://aka.ms/new-console-template for more information


using FullStackBootcamp.App.OOPConcepts.Abstraction;
using FullStackBootcamp.App.OOPConcepts.Inheritance;

Console.WriteLine("Hello, World!");


var orderModule = new OrderModule(new StockRepositoryWithOracle());
orderModule.Create(new Order());


IWriteProductRepository writeProductRepository = new WriteProductRepositoryWithSqlServer();


IReadProductRepository readProductRepository = new ReadProductRepositoryWithSqlSever();


//var person = new Person();


//var teacher = new Teacher();
//teacher.X = "r";
//var loop = new Loop();

//loop.LoopExample(1);

//var tax = new Tax();
//tax.BarcodeCode = "adfdsaf";
//tax.GetNumbers().Clear();
//tax.WriteToConsole();
//tax.SaveToDatabase();