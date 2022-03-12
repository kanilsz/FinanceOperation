using AutoMapper;
using FinanceOperation.Core.Features.BankCards;
using FinanceOperation.Core.Features.DiscountCards;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using FinanceOperation.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceOperation.Core.Features.Users.Create
{
    public class CreateUserFeatureHandler : IRequestHandler<CreateUserFeature>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserFeatureHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateUserFeature request, CancellationToken cancellationToken)
        {
            UserInfo user = _mapper.Map<UserInfo>(request);
            user.DiscountCards = _mapper.Map<IEnumerable<DiscountCard>>(request.DiscountCards);
            user.BankCards = _mapper.Map<IEnumerable<BankCard>>(request.BankCards);

            await _userRepository.Create(user, cancellationToken);

            return Unit.Value;
        }
    }
}
