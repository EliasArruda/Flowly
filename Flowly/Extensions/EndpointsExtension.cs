using Flowly.Features.Auth.Endpoints;

namespace Flowly.Extensions;

public static class EndpointsExtension
{
    public static WebApplication AddEndpoints(this WebApplication app)
    {
        app.MapAuthEndpoint();
        return app;
    }
}
