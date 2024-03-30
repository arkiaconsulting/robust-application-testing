using Contoso.Api.Features.Users;
using Contoso.Core.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationHandlers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapUsers();

app.Run();

public partial class Program
{
    protected Program()
    {
    }
}
