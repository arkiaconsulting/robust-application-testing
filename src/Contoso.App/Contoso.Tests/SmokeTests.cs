using AutoFixture.Xunit2;
using Contoso.Tests.Framework;
using FluentAssertions;
using System.Net.Http.Json;

namespace Contoso.Tests;

[Trait("Category", "Smoke")]
public sealed class SmokeTests : IDisposable
{
    private readonly ContosoWebApplicationFactory _factory = new();

    [Theory(DisplayName = "Creating a user should pass and return its ID"), AutoData]
    public async Task Test01(string firstName, string lastName)
    {
        var client = _factory.CreateClient();
        using var response = await client.PostAsJsonAsync("api/users", new { firstName, lastName });
        response.Should().Be200Ok();
        var id = await response.Content.ReadFromJsonAsync<string>();

        id.Should().NotBeNullOrWhiteSpace();
    }

    [Theory(DisplayName = "Getting a user should return its first and lastNames"), AutoData]
    public async Task Test02(string firstName, string lastName)
    {
        var client = _factory.CreateClient();
        using var response = await client.PostAsJsonAsync("api/users", new { firstName, lastName });
        var id = await response.Content.ReadFromJsonAsync<string>();

        var user = await client.GetFromJsonAsync<TestUser>($"api/users/{id}");

        user.Should().BeEquivalentTo(new { FirstName = firstName, LastName = lastName });
    }

    #region Private
    public void Dispose() => _factory.Dispose();
    #endregion
}

internal sealed record TestUser(string FirstName, string LastName);