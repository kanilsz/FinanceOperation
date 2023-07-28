using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Get;

public class GetUserInfoQuery : IRequest<UserIdentityDto>
{
    public int Id { get; set; }
}
