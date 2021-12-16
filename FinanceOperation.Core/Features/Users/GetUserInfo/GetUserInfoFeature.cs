using MediatR;

namespace FinanceOperation.Core.Features.Users.GetUserInfo
{
    public class GetUserInfoFeature : IRequest<UserInfoDto>
    {
        public string UserId { get; set; }
    }
}
