using AutoFixture.Xunit2;
using Contoso.Core.Application;
using Contoso.Core.Application.Features.Users;
using Contoso.Core.Application.Features.Users.CreateUser;
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

    #region Private
    public void Dispose() => _host.Dispose();
    #endregion
}