using MediatR;

namespace FinanceOperation.Core.Features.Users.GetUserInfo
{
    public class GetUserInfoQuery : IRequest<UserIdentityDto>
    {
        public string UserId { get; set; }
    }
}
