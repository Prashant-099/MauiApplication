using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MauiAppFB.Models
{
    public class CompanyResponse
    {
        [JsonPropertyName("companies")]
        public List<Company> Companies { get; set; } = new();
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }




    }
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyUpdatedByUserId { get; set; }
        public string CompanyAddedByUserId { get; set; } = "1";
  
        public string CompanyName { get; set; }
        public string? CompanyCode { get; set; }
       
        public string CompanyPrintName { get; set; }
        public string? CompanyAddress1 { get; set; }
        public string? CompanyAddress2 { get; set; }
        public string? CompanyAddress3 { get; set; }
       
        
        public string CompanyStateId { get; set; }
        public string CompanyStateCode { get; set; } = "2";
        public string? CompanyEmail { get; set; }
        public string? CompanyMobile { get; set; }
        public string? CompanyTelephone { get; set; }
        public string? CompanyWebsite { get; set; }
        public string? CompanyFax { get; set; }
        public string? CompanyPincode { get; set; }
        public string? CompanyContactPerson { get; set; }
        public string? CompanyCurrency { get; set; }
        public DateTime? CompanyBeginningDate { get; set; }
        public bool CompanyIsGstApplicable { get; set; } = false;
        public string? CompanyGstApplicableFrom { get; set; } = "asd";

        private string? companygstn = string.Empty;
        public string? CompanyGstin
        {
            get => companygstn; set
            {
                companygstn = value?.ToUpper() ?? string.Empty;

                CompanyPanNo = (!string.IsNullOrEmpty(companygstn) && companygstn.Length >= 12)
                            ? companygstn.Substring(2, 10)
                            : string.Empty;
            }
        }

        private string? companypanno;
        public string? CompanyPanNo { get => companypanno; set => companypanno = value?.ToUpper(); }
        public bool CompanyIsLutBond { get; set; } = false;
        public string? CompanyLutBondNo { get; set; }
        public string? CompanyLutBondTo { get; set; }
        public bool CompanyIsEWayBill { get; set; } = false;
        public string? CompanyEWayBillFrom { get; set; }
        public float? CompanyEWayBillLimit { get; set; } = 0.4f;
        public bool CompanyIsEInvoice { get; set; } = false;
        public string? CompanyEInvoiceFrom { get; set; }
        public string? CompanyRegNo { get; set; }
        public string? CompanyCurSymbol { get; set; } = "null";
       
        public string CompanyDecimal { get; set; } = "2";
        public string? CompanyDateFormat { get; set; }
        public string? CompanyRemarks { get; set; }
        public string? CompanyLogo { get; set; }
        public string? CompanyCity { get; set; }
        public string? CompanyCountry { get; set; }
        public string? CompanyTagline1 { get; set; }
        public string? CompanyTagline2 { get; set; }
        public string? CompanyMsmeNo { get; set; }


        //---------
        public bool? CompanyStatus { get; set; } = true;
        //public DateTime CompanyCreated { get; set; }
        //public DateTime CompanyUpdated { get; set; }
        //public string? CompanyUsername { get; set; }
        //public string? CompanyPassword { get; set; }
        //public string? CompanyThemeName { get; set; }
        public string CompanyServiceType { get; set; } = "ALL";
        public string? CompanyState { get; set; }
        //public bool CompanyIsOnline { get; set; }
        //public DateTime CompanyFssExpiry { get; set; }
        //public int CompanyExtendDays { get; set; }
        //public bool CompanyIsMultiBranch { get; set; }



    }




}
