using MediatR;

namespace FinanceOperation.Core.Features.Users.GetUserInfo
{
    public class GetUserInfoQuery : IRequest<UserIdentityDto>
    {
        public int UserId { get; set; }
    }
}
