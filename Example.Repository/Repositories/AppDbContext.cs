using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Repository.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Repository.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleComment> ArticleComments { get; set; }


        public DbSet<ArticleTag> ArticleTags { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}