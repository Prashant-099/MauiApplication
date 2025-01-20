using System;

namespace MauiAppFB.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountCompanyId { get; set; } = "1";
        public string AccountAddedByUserId { get; set; } = "1";
        public string AccountUpdatedByUserId { get; set; } = "1";
        public string AccountCode { get; set; } = "1";
        public string AccountName { get; set; } = "test";
        public string AccountPrintName { get; set; } = "1";
        public int AccountGroupId { get; set; } = 1;
        public int AccountTypeId { get; set; } = 1;
        public string AccountContactPerson { get; set; } = "1";
        public string AccountAddress1 { get; set; } = "1";
        public string AccountAddress2 { get; set; } = "1";
        public string AccountAddress3 { get; set; } = "1";
        public string AccountCity { get; set; } = "1";
        public int AccountStateId { get; set; } = 1;
        public string AccountPincode { get; set; } = "1";
        public string AccountMobile { get; set; } = "1";
        public string AccountPhone { get; set; } = "1";
        public string AccountRemarks { get; set; } = "1";
        public string AccountEmail { get; set; } = "1";
        public string AccountWebsite { get; set; } = "1";
        public string AccountPan { get; set; } = "1";
        public string AccountGstNo { get; set; } = "1";
        public string AccountTanNo { get; set; } = "1";
        public decimal AccountOpening { get; set; } = 1;
        public decimal? AccountClosing { get; set; } = 1;
        public string AccountBalanceType { get; set; } = "st";
        public string AccountYearId { get; set; } = "1";
        public string AccountAgroupId { get; set; } = "1";
        public string AccountMethod { get; set; } = "On Account";
        public decimal AccountCreditLimit { get; set; } = 0;
        public decimal AccountCreditDays { get; set; } = 0;
        public string AccountBankName { get; set; } = "1";
        public string AccountAccNo { get; set; } = "1";
        public string AccountBankBranch { get; set; } = "1";
        public string AccountIfscCode { get; set; } = "1";
        public bool AccountIsEz { get; set; } = true;
        public string AccountRegisterType { get; set; } = "1";
        public string AccountTallyName { get; set; } = "1";
        public bool AccountStatus { get; set; } = true;
        public string AccountGroupName { get; set; } = "1";
        public DateTime AccountCreated { get; set; } = DateTime.UtcNow.Date;
        public DateTime AccountUpdated { get; set; } = DateTime.UtcNow.Date;
        public bool AccountTdsApplicable { get; set; } = false;
        public decimal AccountTdsPercentage { get; set; } = 0;
        public bool AccountUseForBoth { get; set; } = true;
        public string AccountSwiftCode { get; set; } = "1";
        public string AccountIeCode { get; set; } = "1";
        public string AccountAuthDCode { get; set; } = "1";
        public string AccountCountry { get; set; } = "1";
        public string AccountTaxType { get; set; } = "1";
        public string AccountGstDutyHead { get; set; } = "1";
        public string AccountCommType { get; set; } = "1";
        public decimal AccountCommPer { get; set; } = 0;
        public string AccountMsmeNo { get; set; } = "1";
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



