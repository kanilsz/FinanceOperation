﻿using System.Text.Json.Serialization;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Domain.Propositions;

namespace FinanceOperation.Api.Core.Features.Propositions;

public class DepositPropositionDto : IMapFrom<DepositProposition>
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string PropositionNumber { get; set; }

    public double Summary { get; set; }

    public double Percentage { get; set; }

    [JsonIgnore]
    public bool IsDeleted { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }
}
