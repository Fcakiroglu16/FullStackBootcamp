using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndDelegate.App
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public delegate decimal CalculateTaxDelegate(int tax, decimal price);

    internal class FunctionDelegateExample
    {
        public int Type { get; set; }


        public decimal CalculateTax(int tax, decimal price, CalculateTaxDelegate calculateTax)
        {
            return calculateTax(tax, price);
        }

        public decimal CalculateTax(int tax, decimal price, Func<int, decimal, decimal> calculateTax)
        {
            return calculateTax(tax, price);
        }


        public decimal CalculateTaxType3(int tax, int price)
        {
            return price * tax * 1.1m;
        }

        public decimal CalculateTaxType2(int tax, int price)
        {
            return price * tax * 1m;
        }
    }
}