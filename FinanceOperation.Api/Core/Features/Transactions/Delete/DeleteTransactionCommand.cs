using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Domain.Transactions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Transactions.Delete;

public class DeleteTransactionCommand : IRequest, IMapTo<Transaction>
{
    public string UserId { get; set; }
}
