using MediatR;

namespace FinanceOperation.Core.Features.Users.Delete;

public class DeleteUserCommand : IRequest
{
    public string Id { get; set; }
}
