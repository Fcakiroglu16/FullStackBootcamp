// See https://aka.ms/new-console-template for more information


using EventAndDelegate.App;

Console.WriteLine("Delegate And Events");


var categoryRepository = new CategoryRepository();

categoryRepository.SetThresholdCategoryCount(3);

categoryRepository.ThresholdCategoryCountEvent += CategoryRepository_ThresholdCategoryCountEvent;


categoryRepository.ThresholdCategoryCountEvent += CategoryRepository_ThresholdCategoryCountEvent1;


void CategoryRepository_ThresholdCategoryCountEvent(object? sender, int categoryCount)
{
    if (categoryCount >= 4)
    {
        throw new Exception("hata var sayı 4 oldu");
    }

    Console.WriteLine($"kategori sayısı eşik değerini({categoryCount}) aştı(1)");
}


void CategoryRepository_ThresholdCategoryCountEvent1(object? sender, int categoryCount)
{
    Console.WriteLine($"kategori sayısı eşik değerini({categoryCount}) aştı(2)");
}


var category = new Category() { Id = 20, Name = "kalem 20" };
categoryRepository.Add(category);
categoryRepository.Add(category);
categoryRepository.Add(category);
categoryRepository.Add(category);
categoryRepository.Add(category);

//var productEvent = new ProductEvent("kalem 1", 100);

//productEvent.ProductChangedEvent += ProductEventProductChangedEvent;

//void ProductEventProductChangedEvent(object? sender, decimal price)
//{
//    Console.WriteLine($"Product Changed. current Value:  {price}");
//}

//productEvent.ChangePrice(600);


//var person = new Person();

//person.FirstName = "ahmet";
//person.LastName = "yıldız";
//person.ProfilePictureUrl = "https://url.com";

//person.ProfilePictureChanged += (pictureUrl) => { Console.WriteLine($"url değiştir :{pictureUrl}"); };


//var product = new Product();

//product.StockCountEvent += Product_StockCountEvent;

//void Product_StockCountEvent(int stock)
//{
//    Console.WriteLine("Stock is not enough");
//}

//for (int i = 1; i < 30; i++)
//{
//    product.Stock = i;
//    Console.WriteLine(product.Stock);
//    //if (product.StockCount >= product.Stock)
//    //{
//    //Console.WriteLine("Stock is enough");
//    //}
//    //else
//    //{
//    //    Console.WriteLine("Stock is not enough");
//    //}
//}


//SuperSalaryCalculator superSalaryCalculator = new SuperSalaryCalculator();

//superSalaryCalculator.GoodCalculate(100, 2, SalaryCalculator.TesterCalculate);


//var salaryCalculator = new SalaryCalculator();


//var salary = salaryCalculator.GoodCalculate(100, 1, salaryCalculator.ManagerCalculate);

//var salaryAsTester = salaryCalculator.GoodCalculate(100, 1, salaryCalculator.TesterCalculate);


//Console.WriteLine(salary);


//FunctionDelegateExample functionDelegateExample = new FunctionDelegateExample();
//var delegateExample2 = new DelegateExample2();
//Console.WriteLine(delegateExample2.Calculate(2, 5, CalculatorType.Add));
//Console.WriteLine(delegateExample2.GoodCalculate(2, 5, (a, b) =>
//{
//    var result = a + b;
//    result += 1;

//    return result;
//}));

#region Example 3

Operator operator5 = delegate(int a, int b) { return a + b; };
Operator operator6 = (a, b) => { return a + b; };
Operator operator7 = (a, b) => a + b;

Operator3 operator10 = Add2;

//operator10(10);

#endregion

#region Example 1

Operator myOperator = Add;

myOperator += Multiply;

var sum = myOperator.Invoke(2, 5);

//Console.WriteLine($"toplam:{sum}");

#endregion

#region Example 2

Operator2 myOperator2 = Add2;

foreach (Operator myDelegate in myOperator.GetInvocationList())
{
    //Console.WriteLine($"result :{myDelegate(10, 10)}");
}

//multicast delegate
myOperator2 += Multiply2;

myOperator2 += Subtraction2;

myOperator2 -= Subtraction2;

//myOperator2(5, 5);

#endregion


int Add(int a, int b)
{
    return a + b;
}

int Multiply(int a, int b)
{
    return a * b;
}

void Add2(int a, int b = 20)
{
    Console.WriteLine($"Toplam :{a + b}");
}

void Multiply2(int a, int b)
{
    Console.WriteLine($"Çarpım :{a * b}");
}

void Subtraction2(int a, int b)
{
    Console.WriteLine($"Çıkarma :{a - b}");
}

int Subtraction3(int a, int b, int c)
{
    Console.WriteLine($"Çıkarma :{a - b}");
    return 1;
}

internal delegate int Operator(int a, int b);

internal delegate void Operator2(int a, int b);

internal delegate void Operator3(int a, int b = 50);