﻿using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace test
{
    public class ProductFacts : TestBase
    {
        [Fact]
        public void ShouldReturnOk()
        {
            var httpResponseMessage = Server.CreateRequest("api/products").GetAsync().Result;
            Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
        }

        [Fact]
        public void ShouldReturnAllProducts()
        {
            var httpResponseMessage = Server.CreateRequest("api/products").GetAsync().Result;

            var products = Body(httpResponseMessage, new []
            {
                new
                {
                    Name = default(string)
                
                }
            });

            Assert.Equal(1, products.Count());
            Assert.Equal("Subway", products[0].Name);
        }

        public T Body<T>(HttpResponseMessage httpResponseMessage, T anonymousTypeObject)
        {
            return JsonConvert.DeserializeAnonymousType(httpResponseMessage.Content.ReadAsStringAsync().Result, anonymousTypeObject);
        }

    }
}