using Microsoft.EntityFrameworkCore;
using MVC.EFCore.Entities;

namespace MVC.EFCore
{
   public class MyCustomerContext: DbContext
   {
      public MyCustomerContext(DbContextOptions<MyCustomerContext> options): base(options)
      {
            
      }

      public DbSet<Customer> Customers { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         //base.OnModelCreating(modelBuilder);
         //fluent API configuration

         modelBuilder.Entity<Customer>().HasKey(c => c.Id);
         modelBuilder.Entity<Customer>().Property(c => c.Id).ValueGeneratedOnAdd();
      }
   }
}
