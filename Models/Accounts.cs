using System;

namespace MauiAppFB.Models
{
    public class Account
    {  public int AccountId { get; set; }
    public string AccountAddedByUserId { get; set; }
    public string AccountAddedByUser { get; set; } = string.Empty;
    public string? AccountUpdatedByUserId { get; set; }
    public string? AccountUpdatedByUser { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public int AccountGroupId { get; set; }
    public string AccountGroupName { get; set; } = string.Empty;
    public string AccountAddress1 { get; set; } = string.Empty;
    public string AccountAddress2 { get; set; } = string.Empty;
    public string AccountAddress3 { get; set; } = string.Empty;
    public string? AccountCity { get; set; }
        public int? AccountStateId { get; set; } = 0;
    public string? AccountPincode { get; set; }
    public string? AccountEmail { get; set; }
    public string? AccountMobile { get; set; }
    public string? AccountPan { get; set; }
    public string AccountGstNo { get; set; } = string.Empty;
        public int? AccountOpening { get; set; } = 0;
    public string AccountBalanceType { get; set; } = "Dr";
    public bool AccountStatus { get; set; }
    }

    public class AccountsResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<Account> Accounts { get; set; } = new();  // Changed to an array for proper deserialization
    }
}



