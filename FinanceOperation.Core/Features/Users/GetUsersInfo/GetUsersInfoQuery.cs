using MediatR;

namespace FinanceOperation.Core.Features.Users.GetUsersInfo
{
   public class GetUsersInfoQuery : IRequest<IList<UserInfoDto>>
    {
    }
}
