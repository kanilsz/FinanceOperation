using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Delete;

public class DeleteUserCommand : IRequest
{
    public int Id { get; set; }
}
