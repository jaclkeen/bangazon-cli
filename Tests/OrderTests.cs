using System;
using Xunit;
using Bangazon.Orders;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class OrderTests
    {
        [Fact]
        public void TestTheTestingFramework(){
            Assert.True(true);
        }
        [Fact]
        public void OrdersCanExist(){
            Order ord = new Order();
            Assert.NotNull(ord);
        }
        [Fact]
        public void NewOrdersHaveAGuidOfTypeGuid(){
            Order ord = new Order();
            Assert.NotNull(ord.orderNumber);
            Assert.IsType<Guid>(ord.orderNumber);
        }
        [Fact]
        public void NewOrdersShouldHaveAnEmptyProductList(){
            Order ord = new Order();
            Assert.NotNull(ord.products);
            Assert.IsType<List<string>>(ord.products);
            Assert.Empty(ord.products);
        }
        [Theory]
        [InlineDataAttribute("Banana")]
        [InlineDataAttribute("7828982")]
        [InlineDataAttribute("Products with spaces")]
        [InlineDataAttribute("Product, that has a, comma?")]
        public void OrdersCanHaveAProductAddedToThem(string product){
            Order ord = new Order();
            ord.addProduct(product);
            Assert.Equal(1, ord.products.Count);
            Assert.Contains<string>(product, ord.products);
        }
        [Theory]
        [InlineDataAttribute("Product")]
        [InlineDataAttribute("product,another product")]
        [InlineDataAttribute("a first product,someother,yet another")]
        [InlineDataAttribute("prod1,prod2,prod3,prod4")]
        public void OrdersCanHaveMultipleProductsAddedToThem(string productStr){
            string[] products = productStr.Split(new char[] {','});
            Order ord = new Order();
            foreach (string product in products){
                ord.addProduct(product);
            }
            Assert.Equal(products.Length, ord.products.Count);
            foreach(string product in products){
                Assert.Contains<string>(product, ord.products);
            }
        }

        [Theory]
        [InlineDataAttribute("Product")]
        [InlineDataAttribute("product,another product")]
        [InlineDataAttribute("a first product,someother,yet another")]
        [InlineDataAttribute("prod1,prod2,prod3,prod4")]
        public void OrdersCanListProductsForTerminalDisplay(string productStr){
            string[] products = productStr.Split(new char[] {','});
            Order ord = new Order();
            foreach (string product in products){
                ord.addProduct(product);
            }
            foreach(string product in products){
                Assert.Contains($"\nYou ordered {product}", ord.listProducts());
            }
        }

        [Fact]
        public void OrdersCanHaveAProductRemovedFromThem(){
            Order ord = new Order();
            ord.addProduct("Product");
            ord.addProduct("Banana");
            ord.addProduct("Honeydew Melon");

            ord.removeProduct("Banana");

            Assert.Equal(2, ord.products.Count);
            Assert.DoesNotContain<string>("Banana", ord.products);
        }

        [Fact]
        public void OrderCanNotRemoveAProductThatDoesNotExistFromThem(){
            Order ord = new Order();
            ord.addProduct("Product");
            ord.addProduct("Banana");
            ord.addProduct("Honeydew Melon");

            ord.removeProduct("Pineapple");

            Assert.Equal(3, ord.products.Count);
        }

        [Theory]
        [InlineDataAttribute("Banana")]
        [InlineDataAttribute("Pineapple")]
        public void RemoveMethodReturnsBooleanIndicatingIfProductWasRemoved(string product){
            Order ord = new Order();
            ord.addProduct("Banana Bread");
            ord.addProduct("Product");
            ord.addProduct("Banana");
            ord.addProduct("Honeydew Melon");

            bool removed = ord.removeProduct(product);

            if(product == "Banana"){
                Assert.True(removed);
            }
            if(product == "Pineapple"){
                Assert.False(removed);
            }
        }

        [Fact]
        public void AllProductsFromAnOrderCanBeDeleted(){
            Order ord = new Order();
            ord.addProduct("Banana Bread");
            ord.addProduct("Product");
            ord.addProduct("Banana");
            ord.addProduct("Honeydew Melon");

            ord.removeProduct();

            Assert.Empty(ord.products);
        }
    }
}