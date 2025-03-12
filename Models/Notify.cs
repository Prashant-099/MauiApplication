using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MauiAppFB.Models
{
    public class Notify
    {
        public int NotifyId { get; set; }
        public string NotifyCompanyId { get; set; } = "1";
        public int NotifyStateId { get; set; } = 1;
        public string NotifyAddedByUserId { get; set; } = "1";
        public string NotifyUpdatedByUserId { get; set; } = "1";
        public string NotifyName { get; set; } = "1";
        public string NotifyType { get; set; } = "1";
        public string NotifyAddress1 { get; set; } = "1";
        public string NotifyAddress2 { get; set; } = "1";
        public string NotifyAddress3 { get; set; } = "1";
        public string NotifyAddressfull => $"{NotifyAddress1 }{NotifyAddress2}{NotifyAddress3}".Trim();
        public string NotifyCity { get; set; } = string.Empty;
        public string NotifyTel { get; set; } = "1";
        public string NotifyEmail { get; set; } = "1";
        public string NotifyContactNo { get; set; } = string.Empty;
        public string NotifyContactPerson { get; set; } = "1";
        public string NotifyGstNo { get; set; } = string.Empty;
        public string NotifyPan { get; set; } = "1";
        public bool NotifyStatus { get; set; } = true;
        public string NotifyState { get; set; } = "1";
        public string NotifyPincode { get; set; } = "1";
        public string NotifyStateCode { get; set; } = "1";
        public DateTime NotifyCreated { get; set; } = DateTime.UtcNow.Date;
        public DateTime NotifyUpdated { get; set; } = DateTime.UtcNow.Date;
        public string NotifyCountry { get; set; } = "1";
    }

    public class NotifyResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        [JsonPropertyName("notifies")]
        public List<Notify> Notifies { get; set; } = new();
    }
}
