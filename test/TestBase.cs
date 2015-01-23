using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Testing;
using Owin;
using UFO_API;
using Xunit;

namespace test
{
    public class TestBase : IDisposable
    {
        public TestServer Server
        {
            get { return server; }
        }

        private readonly TestServer server;

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
    }
}
