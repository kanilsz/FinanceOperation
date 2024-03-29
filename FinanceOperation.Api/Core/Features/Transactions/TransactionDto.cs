﻿using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Domain.Transactions;

namespace FinanceOperation.Api.Core.Features.Transactions;

internal class TransactionDto : IMapTo<Transaction>, IMapFrom<Transaction>
{
    public string Id { get; set; }
    public string BankName { get; set; }
    public string UserId { get; set; }
    public string Summary { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}
