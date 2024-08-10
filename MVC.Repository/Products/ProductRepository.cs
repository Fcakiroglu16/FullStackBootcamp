using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Repository.Data;

namespace MVC.Repository.Products
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public async Task<List<Product>?> GetAllWithCategoryIdAsync(int categoryId)
        {
            var category = await context.Categories.Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == categoryId);

            return category?.Products;
        }
    }
}