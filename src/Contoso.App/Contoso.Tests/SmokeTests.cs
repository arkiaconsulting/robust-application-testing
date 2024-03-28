using Contoso.Tests.Framework;

namespace Contoso.Tests;

[Trait("Category", "Smoke")]
public class SmokeTests
{
    private readonly ContosoWebApplicationFactory _factory = new();

    [Fact(DisplayName = "")]
    public Task Test01()
    {
        var client = _factory.CreateClient();

        return Task.CompletedTask;
    }
}