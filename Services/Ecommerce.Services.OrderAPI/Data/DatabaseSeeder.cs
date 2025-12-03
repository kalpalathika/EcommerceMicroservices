using Bogus;
using Ecommerce.Services.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.OrderAPI.Data
{
    public class DatabaseSeeder
    {
        private readonly AppDbContext _db;
        private readonly ILogger<DatabaseSeeder> _logger;

        public DatabaseSeeder(AppDbContext db, ILogger<DatabaseSeeder> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task SeedOrdersAsync(int orderCount = 10000)
        {
            _logger.LogInformation($"Starting to seed {orderCount} orders...");

            // Check if we already have enough orders
            var existingOrderCount = await _db.OrderHeaders.CountAsync();
            if (existingOrderCount >= orderCount)
            {
                _logger.LogInformation($"Database already has {existingOrderCount} orders. Skipping seed.");
                return;
            }

            // Grocery products (matching ProductAPI)
            var availableProducts = GetGroceryProducts();

            // Generate 500 unique customer user IDs
            var userIds = GenerateUserIds(500);

            // Order statuses with realistic distribution
            var statuses = new[] { "Pending", "Approved", "Cancelled" };

            // Coupon codes
            var couponCodes = new[] { "SAVE10", "SAVE20", "GROCERY15" };

            // Create Faker for OrderHeader
            var orderHeaderFaker = new Faker<OrderHeader>()
                .RuleFor(o => o.UserId, f => f.PickRandom(userIds))
                .RuleFor(o => o.OrderTime, f => f.Date.Between(
                    DateTime.UtcNow.AddYears(-2),
                    DateTime.UtcNow))
                .RuleFor(o => o.Status, f => f.PickRandom(new[]
                {
                    "Approved", "Approved", "Approved", "Approved", "Approved",
                    "Approved", "Approved", "Approved", "Approved",  // 85%
                    "Pending", // 10%
                    "Cancelled" // 5%
                }))
                .RuleFor(o => o.Name, f => f.Name.FullName())
                .RuleFor(o => o.Email, (f, o) => f.Internet.Email(o.Name?.Replace(" ", "").ToLower()))
                .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber("###-###-####"))
                .RuleFor(o => o.CouponCode, f => f.Random.Int(1, 10) <= 3 ? f.PickRandom(couponCodes) : null)
                .RuleFor(o => o.Discount, (f, o) => o.CouponCode switch
                {
                    "SAVE10" => 10,
                    "SAVE20" => 20,
                    "GROCERY15" => 15,
                    _ => 0
                })
                .RuleFor(o => o.PaymentIntentId, (f, o) => o.Status == "Approved" ?
                    $"pi_{f.Random.AlphaNumeric(24)}" : null)
                .RuleFor(o => o.StripeSessionId, (f, o) => o.Status == "Approved" ?
                    $"cs_test_{f.Random.AlphaNumeric(40)}" : null);

            // Generate orders in batches for performance
            const int batchSize = 1000;
            var totalBatches = (int)Math.Ceiling(orderCount / (double)batchSize);
            var ordersToGenerate = orderCount - existingOrderCount;

            for (int batch = 0; batch < totalBatches; batch++)
            {
                var ordersInBatch = Math.Min(batchSize, ordersToGenerate - (batch * batchSize));
                if (ordersInBatch <= 0) break;

                var orderHeaders = orderHeaderFaker.Generate(ordersInBatch);

                // For each order, create 1-5 order details (line items)
                foreach (var orderHeader in orderHeaders)
                {
                    var faker = new Faker();
                    var itemCount = faker.Random.Int(1, 5); // 1-5 items per order
                    var orderDetails = new List<OrderDetails>();
                    decimal orderTotal = 0;

                    // Select random products for this order
                    var selectedProducts = faker.PickRandom(availableProducts, itemCount);

                    foreach (var product in selectedProducts)
                    {
                        var quantity = faker.Random.Int(1, 4); // 1-4 of each item
                        var lineTotal = (decimal)product.Price * quantity;

                        orderDetails.Add(new OrderDetails
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            Price = product.Price,
                            Count = quantity
                        });

                        orderTotal += lineTotal;
                    }

                    orderHeader.OrderDetails = orderDetails;
                    orderHeader.OrderTotal = (double)(orderTotal - (decimal)orderHeader.Discount);
                }

                // Save batch to database
                await _db.OrderHeaders.AddRangeAsync(orderHeaders);
                await _db.SaveChangesAsync();

                _logger.LogInformation($"Seeded batch {batch + 1}/{totalBatches} ({ordersInBatch} orders with {orderHeaders.Sum(o => o.OrderDetails.Count())} items)");
            }

            var finalCount = await _db.OrderHeaders.CountAsync();
            var totalItems = await _db.OrderDetails.CountAsync();
            _logger.LogInformation($"Seeding complete! Database now has {finalCount} orders with {totalItems} total items.");
        }

        private List<ProductDto> GetGroceryProducts()
        {
            // Match the 20 grocery products from ProductAPI
            return new List<ProductDto>
            {
                // Fruits
                new ProductDto { ProductId = 1, ProductName = "Organic Bananas", Price = 3.99 },
                new ProductDto { ProductId = 2, ProductName = "Red Apples", Price = 4.99 },
                new ProductDto { ProductId = 3, ProductName = "Fresh Oranges", Price = 5.49 },

                // Vegetables
                new ProductDto { ProductId = 4, ProductName = "Tomatoes", Price = 3.49 },
                new ProductDto { ProductId = 5, ProductName = "Potatoes", Price = 2.99 },
                new ProductDto { ProductId = 6, ProductName = "Fresh Carrots", Price = 2.49 },
                new ProductDto { ProductId = 7, ProductName = "Broccoli", Price = 3.99 },

                // Dairy
                new ProductDto { ProductId = 8, ProductName = "Whole Milk (1 Gallon)", Price = 4.79 },
                new ProductDto { ProductId = 9, ProductName = "Cheddar Cheese", Price = 6.99 },
                new ProductDto { ProductId = 10, ProductName = "Greek Yogurt", Price = 5.49 },

                // Pantry
                new ProductDto { ProductId = 11, ProductName = "Brown Rice (2lb)", Price = 7.99 },
                new ProductDto { ProductId = 12, ProductName = "Whole Wheat Bread", Price = 3.99 },
                new ProductDto { ProductId = 13, ProductName = "Pasta (1lb)", Price = 2.49 },

                // Snacks
                new ProductDto { ProductId = 14, ProductName = "Potato Chips", Price = 4.49 },
                new ProductDto { ProductId = 15, ProductName = "Chocolate Chip Cookies", Price = 5.99 },
                new ProductDto { ProductId = 16, ProductName = "Mixed Nuts", Price = 8.99 },

                // Beverages
                new ProductDto { ProductId = 17, ProductName = "Orange Juice (64oz)", Price = 5.99 },
                new ProductDto { ProductId = 18, ProductName = "Bottled Water (12 pack)", Price = 4.99 },
                new ProductDto { ProductId = 19, ProductName = "Green Tea", Price = 6.49 },
                new ProductDto { ProductId = 20, ProductName = "Coffee Beans (1lb)", Price = 12.99 }
            };
        }

        private List<string> GenerateUserIds(int count)
        {
            // Generate realistic user IDs (GUIDs)
            return Enumerable.Range(1, count)
                .Select(i => Guid.NewGuid().ToString())
                .ToList();
        }

        private class ProductDto
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public double Price { get; set; }
        }
    }
}
