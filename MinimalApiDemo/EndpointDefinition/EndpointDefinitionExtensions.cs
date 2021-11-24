namespace MinimalApiDemo.EndpointDefinition
{
  public static class EndpointDefinitionExtensions
  {
    public static void AddEndpointDefinitions(this IServiceCollection services, params Type[] scanMarkers)
    {
      var endpointDefinitions = new List<IEndpointDefinition>();
      foreach (var scanMarker in scanMarkers)
      {
        endpointDefinitions.AddRange(
          scanMarker.Assembly.ExportedTypes
          .Where(t => typeof(IEndpointDefinition).IsAssignableFrom(t) && t.BaseType != null)
          .Select(Activator.CreateInstance).Cast<IEndpointDefinition>()
          );
      }

      foreach (var endpointDefinition in endpointDefinitions)
      {
        endpointDefinition.DefineServices(services);
      }

      services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
    }

    public static void UseEndpointDefinitions(this WebApplication app)
    {
      var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();
      foreach (var definition in definitions)
      {
        definition.DefineEndpoints(app);
      }
    }
  }
}