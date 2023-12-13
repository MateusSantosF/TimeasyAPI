
using timeasy_api.src.Repository;
using TimeasyAPI.src.Services;
using TimeasyAPI.src.Services.Interfaces;

public static class ServiceCollection
{
    public static void RegisterDependencies(this IServiceCollection serviceCollection)
    {

        serviceCollection.AddScoped<ITokenService, TokenService>();
        serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}
