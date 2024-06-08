using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP
{
    internal class JuniorSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal price)
        {
            return price * 1.00m;
        }
    }
}