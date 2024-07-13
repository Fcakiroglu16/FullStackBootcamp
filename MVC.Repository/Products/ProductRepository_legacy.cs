using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Repository.Data;

namespace MVC.Repository.Products
{
    internal class ProductRepository(AppDbContext context)
    {
        // Sql Server/Oracle vb =>  Ado.Net => SqlConnection, SqlCommand, SqlDataReader
        // Sql Server/Oracle vb - Cosmos Db/MongoDb => EF Core => DbContext, DbSet, Migration, Linq to Collection/ Linq To Entity / Linq to XML
        // Sql Server/Oracle vb => Dapper => Mini Orm = Sql clause => Model (Mapping)
    }
}