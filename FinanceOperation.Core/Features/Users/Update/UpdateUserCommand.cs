﻿using AutoMapper;
using FinanceOperation.Core.Features.BankCards;
using FinanceOperation.Core.Features.DiscountCards;
using FinanceOperation.Core.Mapping;
using FinanceOperation.Domain.Users;
using MediatR;

namespace FinanceOperation.Core.Features.Users.Update
{
    public class UpdateUserCommand : IRequest, IMapTo<UserInfo>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public IEnumerable<BankCardDto> BankCards { get; set; }
        public IEnumerable<DiscountCardDto> DiscountCards { get; set; }

        public void MapTo(Profile profile) => profile
            .CreateMap<UpdateUserCommand, UserInfo>()
            .ForMember(dest => dest.BankCards, opt => opt.Ignore())
            .ForMember(dest => dest.DiscountCards, opt => opt.Ignore());
    }
}
