using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UFO_API.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var products = new[]
            {
                new Product
                {
                    Name = "Subway"
                }
            };

            return Request.CreateResponse(HttpStatusCode.OK, products);
        }
    }

    public class Product
    {
        public string Name { get; set; }
    }
}
