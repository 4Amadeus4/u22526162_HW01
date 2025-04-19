using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using u22526162_HW01_API.Controllers;
using u22526162_HW01_API.Models;
using u22526162_HW01_API.Repositories;
using Moq;
using Xunit;

namespace u22526162_HW01_API.Tests.Controllers
{
    public class ProductControllerTest
    {
        [Fact]
        public async Task GetAllProducts_test() {
            var mockRepo = new Mock<IProductRepository>();
            var testProducts = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", ProductPrice = 999.99m, ProductDescription = "High-end laptop" },
            new Product { ProductId = 2, ProductName = "Mouse", ProductPrice = 25.99m, ProductDescription = "Wireless mouse" }
        };

            mockRepo.Setup(repo => repo.GetProductList())
                    .ReturnsAsync(testProducts);

            var controller = new ProductController(mockRepo.Object);
            var result = await controller.GetAllProducts();

            var okResult = Assert.IsType<OkObjectResult>(result.Result); // test OK (HTTP status 200)
            Assert.NotNull(okResult.Value); //test if not null

            var returnedProducts = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(2, returnedProducts.Count);
            Assert.Equal("Laptop", returnedProducts[0].ProductName);
            Assert.Equal("Mouse", returnedProducts[1].ProductName);
        }

        [Fact]
        public async Task GetProductById_test() {
            var mockRepo = new Mock<IProductRepository>();
            var expectedProduct = new Product
            {
                ProductId = 1,
                ProductName = "Laptop",
                ProductPrice = 999.99m,
                ProductDescription = "High-end laptop"
            };

            mockRepo.Setup(repo => repo.GetProductById(1))
                    .ReturnsAsync(expectedProduct);

            var controller = new ProductController(mockRepo.Object);
            var result = await controller.GetProduct(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result); //test if OK (HTTP status 200)
            Assert.NotNull(okResult.Value); //not null test

            var actualProduct = Assert.IsType<Product>(okResult.Value);

            Assert.Equal(expectedProduct.ProductId, actualProduct.ProductId);
            Assert.Equal(expectedProduct.ProductName, actualProduct.ProductName);
            Assert.Equal(expectedProduct.ProductPrice, actualProduct.ProductPrice);
            Assert.Equal(expectedProduct.ProductDescription, actualProduct.ProductDescription);
        }
    }
}
