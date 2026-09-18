namespace Flowly.Features.Auth.Endpoints;

public static class AuthEndpoint
{
    public static IEndpointRouteBuilder MapAuthEndpoint(
        this IEndpointRouteBuilder app
    )
    {
        var router = app.MapGroup("/api/auth");

        router.MapPost("/register", async () =>
        {
            return Results.Ok("Sucess");
        });
        return app;
    }
}
