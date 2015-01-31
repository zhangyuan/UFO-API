using System.Linq;
using System.Net;
using Xunit;

namespace test
{
    public class ProductFacts : TestBase
    {
        [Fact]
        public void ShouldReturnOk()
        {
            Get("api/products");
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
        }

        [Fact]
        public void ShouldReturnAllProducts()
        {
            Get("api/products");

            var products = Body(new []
            {
                new
                {
                    Name = default(string)
                
                }
            });

            Assert.Equal(1, products.Count());
            Assert.Equal("Subway", products[0].Name);
        }
    }
}