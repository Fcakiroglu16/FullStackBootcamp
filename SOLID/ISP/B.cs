using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SOLID.SRP;

namespace SOLID.ISP
{
    internal class B(IWriteProductRepository writeProductRepository)

    {
        public void Update()
        {
            writeProductRepository.Create(new Product());
        }
    }
}