using BlazorServerBudgetApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerBudgetApp.Data.Configuration
{
   public class AppDbContext:DbContext
   {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
      {
            
      }

      public DbSet<Expense> Expenses { get; set; } = default;
      //public DbSet<ExpensesModelForMonth> Budgets { get; set; } = default;
      public DbSet<Note> Notes { get; set; } = default;
      public DbSet<Fund> Funds { get; set; } = default;


   }
}
