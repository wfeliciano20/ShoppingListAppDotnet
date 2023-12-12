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
                new Item { Id = 1, ItemName = "Apples", IsPickedUp = false, ItemQuantity = 5 },
                new Item { Id = 2, ItemName = "Bananas", IsPickedUp = false, ItemQuantity = 3 },
                new Item { Id = 3, ItemName = "Milk", IsPickedUp = false, ItemQuantity = 2 },
                new Item { Id = 4, ItemName = "Bread", IsPickedUp = false, ItemQuantity = 1 },
                new Item { Id = 5, ItemName = "Eggs", IsPickedUp = false, ItemQuantity = 6 },
                new Item { Id = 6, ItemName = "Chicken", IsPickedUp = false, ItemQuantity = 2 },
                new Item { Id = 7, ItemName = "Rice", IsPickedUp = false, ItemQuantity = 1 },
                new Item { Id = 8, ItemName = "Pasta", IsPickedUp = false, ItemQuantity = 3 },
                new Item { Id = 9, ItemName = "Tomatoes", IsPickedUp = false, ItemQuantity = 4 },
                new Item { Id = 10,ItemName = "Potatoes", IsPickedUp = false, ItemQuantity = 5 }
            );
        }
    }
}