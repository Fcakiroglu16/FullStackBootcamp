using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackBootcamp.App.OOPConcepts.Abstraction
{
    internal class StockRepositoryWithOracle : IStockRepository
    {
        public void DecreaseStock(int productId, int count)
        {
            throw new NotImplementedException();
        }

        public bool CheckStock(int productId, int count)
        {
            throw new NotImplementedException();
        }
    }
}