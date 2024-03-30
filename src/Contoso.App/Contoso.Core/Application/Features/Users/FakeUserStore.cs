namespace Contoso.Core.Application.Features.Users;

public class FakeUserStore : List<UserEntity>, IUserStore
{
    Task IUserStore.Add(UserEntity user)
    {
        Add(user);

        return Task.CompletedTask;
    }
}