using AutoFixture.Xunit2;
using Microsoft.Extensions.Hosting;

namespace Contoso.Tests;

[Trait("Category", "Unit")]
public class UnitTests
{
    private readonly IHost _host = Host.CreateDefaultBuilder().Build();

    [Theory(DisplayName = ""), AutoData]
    public Task Test01()
    {
        _ = _host.Services;

        return Task.CompletedTask;
    }
}