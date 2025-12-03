using Ecommerce.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fruits
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Organic Bananas",
                Price = 3.99,
                Description = "Fresh organic bananas, rich in potassium. Perfect for smoothies or snacking.",
                ImageUrl = "https://images.unsplash.com/photo-1571771894821-ce9b6c11b08e?w=400",
                CategoryName = "Fruits"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Red Apples",
                Price = 4.99,
                Description = "Crisp and sweet red apples. Great for eating fresh or baking.",
                ImageUrl = "https://images.unsplash.com/photo-1560806887-1e4cd0b6cbd6?w=400",
                CategoryName = "Fruits"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Fresh Oranges",
                Price = 5.49,
                Description = "Juicy oranges packed with Vitamin C. Perfect for fresh juice.",
                ImageUrl = "https://images.unsplash.com/photo-1547514701-42782101795e?w=400",
                CategoryName = "Fruits"
            });

            // Vegetables
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Tomatoes",
                Price = 3.49,
                Description = "Fresh vine-ripened tomatoes. Essential for salads and cooking.",
                ImageUrl = "https://images.unsplash.com/photo-1546470427-227e365ecca3?w=400",
                CategoryName = "Vegetables"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Potatoes",
                Price = 2.99,
                Description = "Russet potatoes, perfect for baking, mashing, or frying.",
                ImageUrl = "https://images.unsplash.com/photo-1518977676601-b53f82aba655?w=400",
                CategoryName = "Vegetables"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "Fresh Carrots",
                Price = 2.49,
                Description = "Crunchy orange carrots, great for snacking or cooking.",
                ImageUrl = "https://images.unsplash.com/photo-1598170845058-32b9d6a5da37?w=400",
                CategoryName = "Vegetables"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                Name = "Broccoli",
                Price = 3.99,
                Description = "Fresh broccoli florets, packed with nutrients and fiber.",
                ImageUrl = "https://images.unsplash.com/photo-1459411552884-841db9b3cc2a?w=400",
                CategoryName = "Vegetables"
            });

            // Dairy
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                Name = "Whole Milk (1 Gallon)",
                Price = 4.79,
                Description = "Fresh whole milk, rich and creamy. Perfect for drinking or cooking.",
                ImageUrl = "https://images.unsplash.com/photo-1563636619-e9143da7973b?w=400",
                CategoryName = "Dairy"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                Name = "Cheddar Cheese",
                Price = 6.99,
                Description = "Sharp cheddar cheese, aged for bold flavor. Great for sandwiches.",
                ImageUrl = "https://images.unsplash.com/photo-1452195100486-9cc805987862?w=400",
                CategoryName = "Dairy"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 10,
                Name = "Greek Yogurt",
                Price = 5.49,
                Description = "Protein-rich Greek yogurt. Perfect for breakfast or smoothies.",
                ImageUrl = "https://images.unsplash.com/photo-1488477181946-6428a0291777?w=400",
                CategoryName = "Dairy"
            });

            // Pantry
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 11,
                Name = "Brown Rice (2lb)",
                Price = 7.99,
                Description = "Healthy whole grain brown rice. Perfect side dish or base.",
                ImageUrl = "https://images.unsplash.com/photo-1586201375761-83865001e31c?w=400",
                CategoryName = "Pantry"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 12,
                Name = "Whole Wheat Bread",
                Price = 3.99,
                Description = "Freshly baked whole wheat bread. Perfect for sandwiches.",
                ImageUrl = "https://images.unsplash.com/photo-1509440159596-0249088772ff?w=400",
                CategoryName = "Pantry"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 13,
                Name = "Pasta (1lb)",
                Price = 2.49,
                Description = "Italian pasta, perfect for any sauce. Quick and easy meal.",
                ImageUrl = "https://images.unsplash.com/photo-1551462147-37463d4ba10c?w=400",
                CategoryName = "Pantry"
            });

            // Snacks
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 14,
                Name = "Potato Chips",
                Price = 4.49,
                Description = "Crispy salted potato chips. Perfect snack for any occasion.",
                ImageUrl = "https://images.unsplash.com/photo-1566478989037-eec170784d0b?w=400",
                CategoryName = "Snacks"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 15,
                Name = "Chocolate Chip Cookies",
                Price = 5.99,
                Description = "Delicious homestyle chocolate chip cookies. Sweet treat!",
                ImageUrl = "https://images.unsplash.com/photo-1499636136210-6f4ee915583e?w=400",
                CategoryName = "Snacks"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 16,
                Name = "Mixed Nuts",
                Price = 8.99,
                Description = "Premium mixed nuts with almonds, cashews, and pecans.",
                ImageUrl = "https://images.unsplash.com/photo-1599599810769-bcde5a160d32?w=400",
                CategoryName = "Snacks"
            });

            // Beverages
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 17,
                Name = "Orange Juice (64oz)",
                Price = 5.99,
                Description = "Fresh-squeezed orange juice, no added sugar. Pure citrus goodness.",
                ImageUrl = "https://images.unsplash.com/photo-1600271886742-f049cd451bba?w=400",
                CategoryName = "Beverages"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 18,
                Name = "Bottled Water (12 pack)",
                Price = 4.99,
                Description = "Pure spring water, 12-pack of 16.9oz bottles. Stay hydrated!",
                ImageUrl = "https://images.unsplash.com/photo-1548839140-29a749e1cf4d?w=400",
                CategoryName = "Beverages"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 19,
                Name = "Green Tea",
                Price = 6.49,
                Description = "Premium green tea bags. Rich in antioxidants and flavor.",
                ImageUrl = "https://images.unsplash.com/photo-1564890369478-c89ca6d9cde9?w=400",
                CategoryName = "Beverages"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 20,
                Name = "Coffee Beans (1lb)",
                Price = 12.99,
                Description = "Premium arabica coffee beans. Rich, smooth, and aromatic.",
                ImageUrl = "https://images.unsplash.com/photo-1559056199-641a0ac8b55e?w=400",
                CategoryName = "Beverages"
            });
        }
    }
}