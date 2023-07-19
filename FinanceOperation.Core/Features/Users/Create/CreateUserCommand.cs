﻿using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Core.Features.BankCards;
using FinanceOperation.Core.Features.DiscountCards;
using FinanceOperation.Domain.Users;
using MediatR;

namespace FinanceOperation.Core.Features.Users.Create
{
    public class CreateUserCommand : IRequest, IMapTo<UserIdentity>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public IEnumerable<BankCardDto> BankCards { get; set; }
        public IEnumerable<DiscountCardDto> DiscountCards { get; set; }

        public void MapTo(Profile profile) => profile
            .CreateMap<CreateUserCommand, UserIdentity>()
            .ForMember(dest => dest.BankCards, opt => opt.Ignore())
            .ForMember(dest => dest.DiscountCards, opt => opt.Ignore());
    }

}
