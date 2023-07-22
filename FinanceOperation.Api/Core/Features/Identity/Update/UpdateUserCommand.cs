using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Update;

public class UpdateUserCommand : IRequest, IMapTo<UserIdentity>
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }

    public void MapTo(Profile profile)
    {
        _ = profile
        .CreateMap<UpdateUserCommand, UserIdentity>();
    }
}
