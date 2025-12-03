using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductsToGroceries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Fruits", "Fresh organic bananas, rich in potassium. Perfect for smoothies or snacking.", "https://images.unsplash.com/photo-1571771894821-ce9b6c11b08e?w=400", "Organic Bananas", 3.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Fruits", "Crisp and sweet red apples. Great for eating fresh or baking.", "https://images.unsplash.com/photo-1560806887-1e4cd0b6cbd6?w=400", "Red Apples", 4.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Fruits", "Juicy oranges packed with Vitamin C. Perfect for fresh juice.", "https://images.unsplash.com/photo-1547514701-42782101795e?w=400", "Fresh Oranges", 5.4900000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Vegetables", "Fresh vine-ripened tomatoes. Essential for salads and cooking.", "https://images.unsplash.com/photo-1546470427-227e365ecca3?w=400", "Tomatoes", 3.4900000000000002 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 5, "Vegetables", "Russet potatoes, perfect for baking, mashing, or frying.", "https://images.unsplash.com/photo-1518977676601-b53f82aba655?w=400", "Potatoes", 2.9900000000000002 },
                    { 6, "Vegetables", "Crunchy orange carrots, great for snacking or cooking.", "https://images.unsplash.com/photo-1598170845058-32b9d6a5da37?w=400", "Fresh Carrots", 2.4900000000000002 },
                    { 7, "Vegetables", "Fresh broccoli florets, packed with nutrients and fiber.", "https://images.unsplash.com/photo-1459411552884-841db9b3cc2a?w=400", "Broccoli", 3.9900000000000002 },
                    { 8, "Dairy", "Fresh whole milk, rich and creamy. Perfect for drinking or cooking.", "https://images.unsplash.com/photo-1563636619-e9143da7973b?w=400", "Whole Milk (1 Gallon)", 4.79 },
                    { 9, "Dairy", "Sharp cheddar cheese, aged for bold flavor. Great for sandwiches.", "https://images.unsplash.com/photo-1452195100486-9cc805987862?w=400", "Cheddar Cheese", 6.9900000000000002 },
                    { 10, "Dairy", "Protein-rich Greek yogurt. Perfect for breakfast or smoothies.", "https://images.unsplash.com/photo-1488477181946-6428a0291777?w=400", "Greek Yogurt", 5.4900000000000002 },
                    { 11, "Pantry", "Healthy whole grain brown rice. Perfect side dish or base.", "https://images.unsplash.com/photo-1586201375761-83865001e31c?w=400", "Brown Rice (2lb)", 7.9900000000000002 },
                    { 12, "Pantry", "Freshly baked whole wheat bread. Perfect for sandwiches.", "https://images.unsplash.com/photo-1509440159596-0249088772ff?w=400", "Whole Wheat Bread", 3.9900000000000002 },
                    { 13, "Pantry", "Italian pasta, perfect for any sauce. Quick and easy meal.", "https://images.unsplash.com/photo-1551462147-37463d4ba10c?w=400", "Pasta (1lb)", 2.4900000000000002 },
                    { 14, "Snacks", "Crispy salted potato chips. Perfect snack for any occasion.", "https://images.unsplash.com/photo-1566478989037-eec170784d0b?w=400", "Potato Chips", 4.4900000000000002 },
                    { 15, "Snacks", "Delicious homestyle chocolate chip cookies. Sweet treat!", "https://images.unsplash.com/photo-1499636136210-6f4ee915583e?w=400", "Chocolate Chip Cookies", 5.9900000000000002 },
                    { 16, "Snacks", "Premium mixed nuts with almonds, cashews, and pecans.", "https://images.unsplash.com/photo-1599599810769-bcde5a160d32?w=400", "Mixed Nuts", 8.9900000000000002 },
                    { 17, "Beverages", "Fresh-squeezed orange juice, no added sugar. Pure citrus goodness.", "https://images.unsplash.com/photo-1600271886742-f049cd451bba?w=400", "Orange Juice (64oz)", 5.9900000000000002 },
                    { 18, "Beverages", "Pure spring water, 12-pack of 16.9oz bottles. Stay hydrated!", "https://images.unsplash.com/photo-1548839140-29a749e1cf4d?w=400", "Bottled Water (12 pack)", 4.9900000000000002 },
                    { 19, "Beverages", "Premium green tea bags. Rich in antioxidants and flavor.", "https://images.unsplash.com/photo-1564890369478-c89ca6d9cde9?w=400", "Green Tea", 6.4900000000000002 },
                    { 20, "Beverages", "Premium arabica coffee beans. Rich, smooth, and aromatic.", "https://images.unsplash.com/photo-1559056199-641a0ac8b55e?w=400", "Coffee Beans (1lb)", 12.99 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Appetizer", " Quisque vel lacus ac magna, vehicula sagittis ut non lacus.<br/> Vestibulum arcu turpis, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://placehold.co/603x403", "Samosa", 15.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Appetizer", " Quisque vel lacus ac magna, vehicula sagittis ut non lacus.<br/> Vestibulum arcu turpis, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://placehold.co/602x402", "Paneer Tikka", 13.99 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Dessert", " Quisque vel lacus ac magna, vehicula sagittis ut non lacus.<br/> Vestibulum arcu turpis, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://placehold.co/601x401", "Sweet Pie", 10.99 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Entree", " Quisque vel lacus ac magna, vehicula sagittis ut non lacus.<br/> Vestibulum arcu turpis, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://placehold.co/600x400", "Pav Bhaji", 15.0 });
        }
    }
}
