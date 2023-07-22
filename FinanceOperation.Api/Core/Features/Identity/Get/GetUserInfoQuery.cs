using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Get;

public class GetUserInfoQuery : IRequest<UserIdentityDto>
{
    public int UserId { get; set; }
}
