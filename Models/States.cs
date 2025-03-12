using MauiAppFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{
    public class States
    {

        [JsonPropertyName("stateId")]
        public int StateId { get; set; }

        [JsonPropertyName("stateCompanyId")]
        public string StateCompanyId { get; set; }

        [JsonPropertyName("stateAddedByUserId")]
        public string StateAddedByUserId { get; set; } = "1";

        [JsonPropertyName("stateUpdatedByUserId")]
        public string StateUpdatedByUserId { get; set; } = "1";

        [JsonPropertyName("stateName")]
        public string StateName { get; set; }

        [JsonPropertyName("stateCode")]
        public string StateCode { get; set; } 

        [JsonPropertyName("stateStatus")]
        public int StateStatus { get; set; } = 1;

        [JsonPropertyName("stateCreated")]
        public DateTime StateCreated { get; set; } = DateTime.UtcNow.Date;

        [JsonPropertyName("stateUpdated")]
        public DateTime StateUpdated { get; set; } = DateTime.UtcNow.Date;
    }

    public class StatesResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        [JsonPropertyName("states")]
        public List<States> states { get; set; } = new();
    }
}