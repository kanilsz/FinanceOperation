using System.Text.Json.Serialization;

namespace FinanceOperation.Api.Core.Features.Propositions;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PropositionType : byte
{
    Credit,
    Deposit
}
