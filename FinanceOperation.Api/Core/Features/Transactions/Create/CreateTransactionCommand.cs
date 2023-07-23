using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Domain.Transactions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Transactions.Create;

public class CreateTransactionCommand : IRequest<Unit>, IMapTo<Transaction>, IMapFrom<Transaction>
{
    public string BankName { get; set; }
    public string UserId { get; set; }
    public string Summary { get; set; }

    public void MapTo(Profile profile)
    {
        _ = profile
       .CreateMap<CreateTransactionCommand, Transaction>();
    }
}
