namespace FullStackBootcamp.App.Constructors
{
    internal class ProductX
    {
        public static int Tax { get; set; } // static member;
        public string Name { get; set; } // instance member

        public int Count { get; set; } // instance member;


        public static int TaxCalculate(int Tax)
        {
            return Tax * 100;
        }

        public int TaxCalculate2()
        {
            return Tax * 200;
        }


        static ProductX()
        {
            Tax = 20;
        }


        //Explicit
        public ProductX()
        {
            Name = "Kalem 1";
            Count = 2;
        }

        public ProductX(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
}