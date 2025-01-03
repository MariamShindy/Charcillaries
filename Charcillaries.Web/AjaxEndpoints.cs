using Charcillaries.Web.Endpoints;

namespace Charcillaries.Web;

public class AjaxEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        LogoutEndpoint.Map(app);
        ChangeCultureEndpoint.Map(app);
    }
}