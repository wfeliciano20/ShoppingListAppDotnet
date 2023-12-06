using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Models;
using System.Collections.Generic;

namespace ShoppingListApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; } = null!;
    }
}