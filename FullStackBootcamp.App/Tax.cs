using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FullStackBootcamp.App
{
    class Tax
    {
        public decimal CalculateTaxWithSwitch(int price, int type)
        {
            var priceWithTax = 0;
            switch (type)
            {
                case 1:
                    priceWithTax = (int)price * 10 / 100;
                    break;
                case 2:
                    priceWithTax = (int)price * 10 / 100;
                    break;
                case 3:
                    priceWithTax = (int)price * 10 / 100;
                    break;
            }

            return priceWithTax;
        }


        public int CalculateTax(decimal price, int rate)
        {
            var priceWithTax = 0;


            if (rate == 10)
            {
                priceWithTax = (int)price * 10 / 100;
            }

            else if (rate == 20)
            {
                priceWithTax = (int)price * 20 / 100;
            }

            else if (rate == 30)
            {
                priceWithTax = (int)price * 30 / 100;
            }

            else
            {
                priceWithTax = (int)price * 40 / 100;
            }

            return priceWithTax;
        }

        public int CalculateTax2(decimal price, int rate)
        {
            if (rate == 10)
            {
                return (int)price * 10 / 100;
            }

            if (rate == 20)
            {
                return (int)price * 20 / 100;
            }


            if (rate == 30)
            {
                return (int)price * 30 / 100;
            }

            throw new Exception("rate değeri 10-30 arasında olmalıdır.");
        }

        public void Calculate(decimal price, int rate)
        {
            var priceWithTax = 0;

            if (rate == 10)
            {
                priceWithTax = (int)price * 10 / 100;
                Console.WriteLine(priceWithTax);
                return;
            }

            if (rate == 20)
            {
                priceWithTax = (int)price * 20 / 100;
                Console.WriteLine(priceWithTax);
            }

            if (rate == 30)
            {
                priceWithTax = (int)price * 30 / 100;
                Console.WriteLine(priceWithTax);
            }
        }
    }

    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public bool Validate()
        {
            //Guard Clause
            // Fast Fail

            if (string.IsNullOrEmpty(Password))
            {
                return false;
            }


            if (string.IsNullOrEmpty(Password))
            {
                return false;
            }

            if (Password.StartsWith("1234"))
            {
                return false;
            }

            if (Password.Length > 8)
            {
                return false;
            }


            return true;
        }
    }
}