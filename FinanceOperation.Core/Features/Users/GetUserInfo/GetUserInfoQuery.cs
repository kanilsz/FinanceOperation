using MediatR;

namespace FinanceOperation.Core.Features.Users.GetUserInfo
{
    public class GetUserInfoQuery : IRequest<UserInfoDto>
    {
        public string UserId { get; set; }
    }
}
