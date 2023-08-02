using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Core.Features.Propositions;
using FinanceOperation.Api.Domain.Users;

namespace FinanceOperation.Api.Core.Features.UserData.GetUserData;

public record UserDataDto : IMapFrom<UserIdentity>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

    public IList<CreditPropositionDto> Credits { get; set; }
    public IList<DepositPropositionDto> Deposits { get; set; }

    public IList<BankCardDto> BankCards { get; set; }
    public IList<DiscountCardDto> Discounts { get; set; }
}
