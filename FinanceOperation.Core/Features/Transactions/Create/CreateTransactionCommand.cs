using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Domain.Transactions;
using MediatR;

namespace FinanceOperation.Core.Features.Transactions.Create;

public class CreateTransactionCommand : IRequest, IMapTo<Transaction>, IMapFrom<Transaction>
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
