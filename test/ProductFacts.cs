using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace test
{
    public class ProductFacts : TestBase
    {
        private HttpResponseMessage httpResponseMessage;

        [Fact]
        public void ShouldReturnOk()
        {
            var httpResponseMessage = Server.CreateRequest("api/products").GetAsync().Result;
            Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
        }

        [Fact]
        public void ShouldReturnAllProducts()
        {
            httpResponseMessage = Get("api/products");

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

        private HttpResponseMessage Get(string path)
        {
            var httpResponseMessage = Server.CreateRequest(path).GetAsync().Result;
            return httpResponseMessage;
        }

        public T Body<T>(T anonymousTypeObject)
        {
            return JsonConvert.DeserializeAnonymousType(httpResponseMessage.Content.ReadAsStringAsync().Result, anonymousTypeObject);
        }

    }
}