using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndDelegate.App
{
    public enum CalculatorType
    {
        Add,
        Extraction,
        Multiply,
        Divide
    }

    public delegate int Calculator(int a, int b);

    internal class DelegateExample2
    {
        public int BuiltInCalculate(int a, int b, Func<int, int, int> calculator)
        {
            return calculator.Invoke(a, b);
        }

        public int GoodCalculate(int a, int b, Calculator calculator)
        {
            return calculator.Invoke(a, b);
        }


        public int Calculate(int a, int b, CalculatorType calculatorType)
        {
            var result = 0;
            switch (calculatorType)
            {
                case CalculatorType.Add:
                    result = a + b;
                    break;
                case CalculatorType.Extraction:
                    result = a - b;
                    break;
                case CalculatorType.Multiply:
                    result = a * b;
                    break;
                case CalculatorType.Divide:
                    result = a / b;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}