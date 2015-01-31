using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using Owin;
using UFO_API;

namespace test
{
    public class TestBase : IDisposable
    {
        public TestServer Server
        {
            get { return server; }
        }

        private readonly TestServer server;
        protected HttpResponseMessage Response;

        public TestBase()
        {
            server = TestServer.Create(app =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                app.UseWebApi(config);

            }); 
        }

        public void Dispose()
        {
            if (server != null)
                server.Dispose();
        }

        protected void Get(string path)
        {
            Response = Server.CreateRequest(path).GetAsync().Result;
        }

        public T Body<T>(T anonymousTypeObject)
        {
            return JsonConvert.DeserializeAnonymousType(Response.Content.ReadAsStringAsync().Result, anonymousTypeObject);
        }
    }
}
