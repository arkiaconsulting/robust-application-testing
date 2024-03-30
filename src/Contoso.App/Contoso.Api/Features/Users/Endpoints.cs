using Contoso.Core.Application.Features.Users;
using Contoso.Core.Application.Features.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Api.Features.Users;

internal static class Endpoints
{
    public static void MapUsers(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/users");

        group.MapPost("", async (CreateUser request, [FromServices] ISender sender) =>
        {
            var command = new CreateUserCommand(request.FirstName, request.LastName);

            var id = await sender.Send(command);

            return TypedResults.Ok(id);
        });

        group.MapGet("/{id}", (string id, [FromServices] FakeUserStore store) =>
        {
            var user = store.Single(u => u.Id == id);

            return TypedResults.Ok(new { user.FirstName, user.LastName });
        });
    }
}
