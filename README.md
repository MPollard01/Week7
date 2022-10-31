# Week 7

## ASP.NET Razor Pages
- What do ASP.NET API and ASP.NET Razor pages apps have in common?  What are the differences?
  - They use RESTful services
  - Allow CRUD operations
  - API uses Controllers and Razor pages use ViewModels
- Where does dependency injection take place in a Razor Pages application?
  - In the components, using @inject directive
- Where is the database context registered with the Dependency Injection container?
  - In the Program.cs file, with the services
- What are the advantages/disadvantages of adding a service to the DI container with Singleton lifetime?
  - it’s great to use when you need to “share” data inside a class across multiple requests because a singleton holds “state” for the lifetime of the application.
  - the disadvantage is that it can be unsafe
- What other lifetimes are available?  What is the default lifetime for a database context class?
  - Scoped and Transient
  - defualt is transient
- What is in the Web folder of an ASP.NET application?
  - 
What actions happen on startup of an ASP.NET application?
Where does data validation take place in Web application?
What happens to data validation if javascript is disabled on the client browser?
How are the default web pages structured?
How are requests routed to the correct page and method?
How and why do the PageModel classes use asychronous methods?
Why would we want to seed the database?

## More about Web Frameworks
What do Razor Pages, MVC and API applications have in common? 
What is model binding?
What is the difference between Razor Pages and MVC Web applications?
What is Razor markup?
Where/when is the C# code in a Razor page executed?
Where/when is the Javascript code in a Razor page executed?
How is C# code indicated in Razor pages?

## Authorisation and Authentication
What is the difference between Authorisation and Authentication?
Where do they sit in the Request pipeline and why?
What are Roles?
Can a User have more than one Role?
Can an anonymous user have a role?

## Service Lifetimes
1. AddTransient
- Transient lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless services.

2. AddScoped
- Scoped lifetime services are created once per request.

3. AddSingleton
- Singleton lifetime services are created the first time they are requested (or when ConfigureServices is run if you specify an instance there) and then every subsequent request will use the same instance.

## Data Binding
- conversion of data comes with an HTTP request into endpoint parameters and/or Controller or PageModel properties

## Authentication
- authentication supports:
  - User login
  - new user registration
  - password reset

## Authorisation
- a user can be assigned more than one role
- endpoint attributes can specify which roles are authorised to access the endpoint
- annonymous users cannot be assigned roles
