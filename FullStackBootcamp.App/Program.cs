// See https://aka.ms/new-console-template for more information


using FullStackBootcamp.App.Constructors;
using FullStackBootcamp.App.OOPConcepts.Abstraction;
using FullStackBootcamp.App.OOPConcepts.Inheritance;
using FullStackBootcamp.App.OOPConcepts.Polymorphism;
using Monitor = FullStackBootcamp.App.OOPConcepts.Polymorphism.Monitor;
using Teacher = FullStackBootcamp.App.OOPConcepts.Abstraction.Teacher;


var phone = new Phone() { Id = 1, Name = "Kalem 1", Price = 200 };
phone.Save();
var monitor = new Monitor() { Id = 1, Name = "Kalem 2", Price = 300 };
monitor.Save();


//var computer = new Computer();


//var product = new ProductX("kalem 1", 20);
//var product2 = new ProductX("kalem 2", 20);
//var product3 = new ProductX("kalem 3", 20);

//Console.WriteLine("Hello, World!");


//var orderModule = new OrderModule(new StockRepositoryWithOracle());
//orderModule.Create(new Order());


//IWriteProductRepository writeProductRepository = new WriteProductRepositoryWithSqlServer();

//WriteProductRepositoryAbstract writeProductRepositoryAbstract = new WriteProductRepositoryWithSqlServer2();


//IReadProductRepository readProductRepository = new ReadProductRepositoryWithSqlSever();


//var teacher = new Teacher();
//teacher.GetFullName;
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