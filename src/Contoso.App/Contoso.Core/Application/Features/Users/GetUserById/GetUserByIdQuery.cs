using MediatR;

namespace Contoso.Core.Application.Features.Users.GetUserById;

public sealed record GetUserByIdQuery(string Id) : IRequest<UserEntity>
{
    internal sealed class Handler : IRequestHandler<GetUserByIdQuery, UserEntity>
    {
        private readonly IUserStore _store;

        public Handler(IUserStore store) => _store = store;

        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _store.GetById(request.Id);

            return user;
        }
    }
}
