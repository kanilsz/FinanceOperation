﻿namespace FinanceOperation.Api.Interactions.WebApi.Features.Transactions;

public class CreateUserTransactionRequest
{
    public required string UserId { get; set; }
    public required string BankName { get; set; }
    public required string Summary { get; set; }
}