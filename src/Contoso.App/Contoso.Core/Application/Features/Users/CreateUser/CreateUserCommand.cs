using MediatR;

namespace Contoso.Core.Application.Features.Users.CreateUser;

public sealed record CreateUserCommand(string FirstName, string LastName) : IRequest<string>
{
    internal sealed class Handler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserStore _store;

        public Handler(IUserStore store) => _store = store;

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid().ToString();

            var user = new UserEntity(id, request.FirstName, request.LastName);

            await _store.Add(user);

            return id;
        }
    }
}
