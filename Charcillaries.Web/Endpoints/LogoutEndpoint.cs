using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Charcillaries.Web.Endpoints;

public class LogoutEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder self)
    {
        self.MapPost("/logout", async (HttpContext context) =>
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Results.LocalRedirect("/");
        });
    }
}