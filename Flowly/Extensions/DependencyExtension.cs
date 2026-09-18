using Flowly.Features.Auth.Services;

namespace Flowly.Extensions;

public static class DependencyExtension
{
    public static IServiceCollection AddDependency(this IServiceCollection services)
    {
        services.AddHttpClient<IAuthService, AuthService>(client =>
               {
                   client.BaseAddress = new Uri("http://localhost:5076/");
               });
        return services;
    }
}
