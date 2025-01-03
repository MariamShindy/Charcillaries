using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Charcillaries.Web.Endpoints;

public class ChangeCultureEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder self)
    {
        self.MapPost("/change-culture",
            (HttpContext context, [FromForm] string culture, [FromQuery] string returnUrl) =>
            {
                context.Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);
                context.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));

                return Results.LocalRedirect(string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl);
            });
    }
}