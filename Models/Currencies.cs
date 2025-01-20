using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MauiAppFB.Models
{
    public class Currencies
    {
        public int CurrencyId { get; set; }
        public string? CurrencyUuid { get; set; } = "1";
        public string CurrencyCompanyId { get; set; } = "1";
        public string CurrencyAddedByUserId { get; set; } = "1";
        public string CurrencyUpdatedByUserId { get; set; } = "1";
        public string CurrencyName { get; set; } = string.Empty;
        public bool CurrencyStatus { get; set; } = true;
        public DateTime CurrencyCreated { get; set; } = DateTime.UtcNow.Date;
        public DateTime CurrencyUpdated { get; set; } = DateTime.UtcNow.Date;
        public string CurrencySymbol { get; set; } = string.Empty;
    }

    public class CurrenciesResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        [JsonPropertyName("currencies")]
        public List<Currencies> Currencies { get; set; } = new();
    }
}
