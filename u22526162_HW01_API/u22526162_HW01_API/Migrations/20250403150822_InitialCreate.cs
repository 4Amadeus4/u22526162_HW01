using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace u22526162_HW01_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductDescription", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { 1, "A classic baseball cap with adjustable strap, made of breathable cotton. Perfect for casual wear and outdoor activities.", "Baseball Cap", 9.99m },
                    { 2, "Lightweight and breathable running shoes with cushioned soles for enhanced comfort. Designed for maximum comfort and durability, making them ideal for long-distance running or daily workouts.", "Running Shoes", 99.99m },
                    { 3, "Blue shirt with logo on front, made from breathable cotton.", "Blue Shirt", 49.99m },
                    { 4, "HP Laptop with Intel i7 CPU, 16GB RAM, 256GB storage, OLED display", "Laptop", 999.99m },
                    { 5, "Bluetooth mouse with RGB lights and wireless charging pad.", "Wireless Mouse", 79.99m },
                    { 6, "High-capacity fast-charging power bank for mobile devices.", "Portable Power Bank", 59.86m },
                    { 7, "Feature-packed smartwatch with heart rate monitoring, GPS, and Bluetooth connectivity.", "Smartwatch", 199.34m },
                    { 8, "Over-ear wireless headphones with active noise cancellation and long battery life.", "Noise-Canceling Headphones", 149.99m },
                    { 9, "Mechanical gaming keyboard with customizable RGB backlighting and programmable macro keys.", "Gaming Keyboard", 127.19m },
                    { 10, "Water-resistant, lightweight camping tent suitable for 4 people, easy to set up and carry.", "Camping Tent", 190.01m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
