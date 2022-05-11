using AutoMapper;
using FinanceOperation.Core.Features.BankCards;
using FinanceOperation.Core.Features.DiscountCards;
using FinanceOperation.Core.Mapping;
using FinanceOperation.Domain.Users;

namespace FinanceOperation.Core.Features.Users
{
    public class UserInfoDto : IMapFrom<UserInfo>, IMapTo<UserInfo>
    {
        public string Id {get;set;}
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public IEnumerable<BankCardDto> BankCards { get; set; }
        public IEnumerable<DiscountCardDto> DiscountCards { get; set; }

        public void MapFrom(Profile profile) => profile
            .CreateMap<UserInfo, UserInfoDto>();
    }
}
