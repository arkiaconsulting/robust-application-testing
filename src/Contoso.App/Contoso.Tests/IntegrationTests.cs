using Microsoft.Extensions.Hosting;

namespace Contoso.Tests
{
    [Trait("Category", "Integration")]
    public class IntegrationTests
    {
        private readonly IHost _host = Host.CreateDefaultBuilder().Build();

        [Fact(DisplayName = "")]
        public Task Test01()
        {
            _ = _host.Services;

            return Task.CompletedTask;
        }
    }
}