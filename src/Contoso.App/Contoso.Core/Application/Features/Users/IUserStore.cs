namespace Contoso.Core.Application.Features.Users;

public interface IUserStore
{
    Task Add(UserEntity user);
}
