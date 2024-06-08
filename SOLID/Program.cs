// See https://aka.ms/new-console-template for more information


using SOLID.DIP;

Console.WriteLine("Hello, World!");


var productService = new ProductService(new ProductRepositoryWithMySql());

var products = productService.GetProducts();

foreach (var product in products)
{
    Console.WriteLine(product);
}


//var isSuccess = false;
//BasePhone basePhone;


//if (isSuccess)
//{
//    basePhone = new Iphone();
//}
//else
//{
//    basePhone = new Nokia3310();
//}


//basePhone.Call();

//((ITakePhoto)basePhone).TakePhoto();


//if (basePhone is ITakePhoto phone)
//{
//    phone.TakePhoto();
//}


//if (basePhone as ITakePhoto is not null)
//{
//}


//basePhone.TakePhoto();


//var salaryCalculate = new SalaryCalculateService();


//var managerSalary = salaryCalculate.CalculateSalary(100, SalaryType.Manager);

//Console.WriteLine($"managerSalary:{managerSalary}");


//var managerSalary2 = salaryCalculate.GoodCalculateSalary(100, new JuniorSalaryCalculate());

//Console.WriteLine($"managerSalary2:{managerSalary2}");


//client

//var productService = new ProductService(new ProductRepository("a"), new StockRepository());

//productService.Add(new Product() { Id = 1, Name = "Kalem 1", Price = 100 });