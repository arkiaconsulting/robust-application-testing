using Contoso.Core.Application.Features.Users.CreateUser;
using Contoso.Core.Application.Features.Users.GetUserById;
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

        group.MapGet("/{id}", async (string id, [FromServices] ISender sender) =>
        {
            var user = await sender.Send(new GetUserByIdQuery(id));

            return TypedResults.Ok(user);
        });
    }
}
