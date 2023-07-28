using System.Text.Json.Serialization;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Domain.Users;

namespace FinanceOperation.Api.Core.Features.Identity;

public class UserIdentityDto : IMapFrom<UserIdentity>, IMapTo<UserIdentity>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

    [JsonIgnore]
    public bool? IsDeleted { get; set; }
}
