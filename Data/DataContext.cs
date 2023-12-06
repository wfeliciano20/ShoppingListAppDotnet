using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Models;
using System.Collections.Generic;

namespace ShoppingListApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Apples", IsPickedUp = false, Quantity = 5 },
                new Item { Id = 2, Name = "Bananas", IsPickedUp = false, Quantity = 3 },
                new Item { Id = 3, Name = "Milk", IsPickedUp = false, Quantity = 2 },
                new Item { Id = 4, Name = "Bread", IsPickedUp = false, Quantity = 1 },
                new Item { Id = 5, Name = "Eggs", IsPickedUp = false, Quantity = 6 },
                new Item { Id = 6, Name = "Chicken", IsPickedUp = false, Quantity = 2 },
                new Item { Id = 7, Name = "Rice", IsPickedUp = false, Quantity = 1 },
                new Item { Id = 8, Name = "Pasta", IsPickedUp = false, Quantity = 3 },
                new Item { Id = 9, Name = "Tomatoes", IsPickedUp = false, Quantity = 4 },
                new Item { Id = 10, Name = "Potatoes", IsPickedUp = false, Quantity = 5 }
            );
        }
    }
}