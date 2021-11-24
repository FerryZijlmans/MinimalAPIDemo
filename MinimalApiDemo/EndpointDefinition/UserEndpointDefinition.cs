using MinimalApiDemo.Data;
using MinimalApiDemo.model;

namespace MinimalApiDemo.EndpointDefinition
{
  public class UserEndpointDefinition : IEndpointDefinition
  {
    public void DefineEndpoints(WebApplication app)
    {
      app.MapGet("/users", GetUsers);

      app.MapGet("/users/{id}", GetUser);

      app.MapPost("/users", CreateUser);
    }

    public void DefineServices(IServiceCollection services)
    {
      services.AddSingleton<IUserService, UserService>();
    }

    public IResult GetUser(IUserService service, Guid id)
    {
      var user = service.GetUser(id);
      return user is not null ? Results.Ok(user) : Results.NotFound();
    }

    public IResult GetUsers(IUserService service)
    {
      return Results.Ok(service.GetUsers());
    }

    public IResult CreateUser(IUserService service, User user)
    {
      service.CreateUser(user);
      return Results.Created($"Users/{user.Id}", user);
    }
  }
}
