﻿using AutoMapper;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using FinanceOperation.Domain.Users;
using MediatR;

namespace FinanceOperation.Core.Features.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserInfo user = _mapper.Map<UserInfo>(request);
            user.DiscountCards = _mapper.Map<IList<DiscountCard>>(request.DiscountCards);
            user.BankCards = _mapper.Map<IList<BankCard>>(request.BankCards);

            await _userRepository.Create(user, cancellationToken);

            return Unit.Value;
        }
    }
}
