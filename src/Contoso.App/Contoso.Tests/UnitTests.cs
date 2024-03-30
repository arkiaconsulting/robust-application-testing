using AutoFixture.Xunit2;
using Contoso.Core.Application;
using Contoso.Core.Application.Features.Users;
using Contoso.Core.Application.Features.Users.CreateUser;
using Contoso.Core.Application.Features.Users.GetUserById;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Contoso.Tests;

[Trait("Category", "Unit")]
public sealed class UnitTests : IDisposable
{
    private ISender Sut => _host.Services.GetRequiredService<ISender>();
    private FakeUserStore Store => _host.Services.GetRequiredService<FakeUserStore>();

    private readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureServices(services => services.AddApplicationHandlers())
        .Build();

    [Theory(DisplayName = "Creating a user should store it"), AutoData]
    public async Task Test01(CreateUserCommand command)
    {
        var id = await Sut.Send(command);

        Store.Should().ContainEquivalentOf(new { Id = id, command.FirstName, command.LastName });
    }

    [Theory(DisplayName = "Getting an existing user should pass"), AutoData]
    public async Task Test02(string userId, string firstName, string lastName)
    {
        Store.Add(new(userId, firstName, lastName));

        var actualUser = await Sut.Send(new GetUserByIdQuery(userId));

        actualUser.Should().BeEquivalentTo(new { Id = userId, FirstName = firstName, LastName = lastName });
    }

    #region Private
    public void Dispose() => _host.Dispose();
    #endregion
}