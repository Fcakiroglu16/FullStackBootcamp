using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackBootcamp.App.OOPConcepts.Abstraction
{
    public class Order
    {
    }

    internal class OrderModule
    {
        private IStockRepository _stockModule;

        public OrderModule(IStockRepository stockModule)
        {
            _stockModule = stockModule;
        }


        public void Create(Order newOrder)
        {
            var hasStock = _stockModule.CheckStock(1, 2);

            if (hasStock == false)
            {
            }
            // create order


            _stockModule.DecreaseStock(1, 4);


            //   DecreaseStock(orderId,count)
        }
    }
}