# UFO-API
Sample application of Web API using Owin as test server

> Attention: 
>
> 1. The application is built with Visual Studio 2013 orignally.
> 2. The .gitignore is borrowed from VisualStudio.gitignore of https://github.com/github/gitignore



## Steps ( Visual Studio 2013)

1. Create "ASP.NET Empty Web Application" called "UFO-API".
2. Create and add "Class Library" called "test" to the solution just created. 
3. Add "UFO-API" to references of "test" project.
4. Add xUnit.net to "test" project using "Package Manager Console" ("Default project" must be "test") by using:

  ```
  Install-Package xunit
  ```
4. Add a folder called "Controllers" to "UFO-API".
5. Right click "UFO-API" in Solution Explorer and add "controller" of "Web API 2 Controller - Empty" called "ProductsController". Visual Studio then will add scaffolds and an empty controller.
6. Install packages for test server using following 2 commands in "Package Manager Console" ("Default project" must be "test"):

  ```
  Install-Package Microsoft.AspNet.WebApi.OwinSelfHost
  Install-Package Microsoft.Owin.Testing
  ```
7. Create the test server with `WebApiConfig` and then use the server to create request in the tests.

## Steps (Visual Studio 2012)

The "ASP.NET Empty Web Application" in VS 2013 doesn't create scaffolds when adding the first Controller. But you can create an "ASP.NET MVC4 Web Application" and then select the "Empty" template. In order to create controller, you have to just create a class inherited from `ApiController` .

## Tips

1. When setup the app in IIS, the corresponding `.NET Framework Version` must be set to `v4.0` in Application pools.
2. As far as I know, the "main" project must be added to "test" project references as soon as it created. If other libraries are added first, they might result in failure in building.
