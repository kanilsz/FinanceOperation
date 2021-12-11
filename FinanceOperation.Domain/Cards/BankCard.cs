﻿using Newtonsoft.Json;

namespace FinanceOperation.Domain.Cards
{
    public class BankCard
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id => CardNumber;
        public string? CardNumber { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}