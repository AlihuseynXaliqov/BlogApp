using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Context
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
             : base(options)
        {
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Product>()
                    .HasOne(p => p.Category) // Product -> Category (Many-to-One)
                    .WithMany(c => c.Products) // Category -> Products (One-to-Many)
                    .HasForeignKey(p => p.CategoryId) // Foreign Key in Product
                    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
