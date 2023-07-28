using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Update;

public class UpdateUserCommand : IRequest, IMapTo<UserIdentity>
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public bool? IsDeleted { get; set; }
}
