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
        public string CompanyUpdatedByUserId { get; set; }  = "1";
        public string CompanyAddedByUserId { get; set; }  = "1";            
        public string CompanyName { get; set; } 
        public string CompanyCode { get; set; }  
        public string CompanyPrintName { get; set; }  = "1";
        public string CompanyAddress1 { get; set; }  = "1";                     
        public string CompanyAddress2 { get; set; }  = "1";
        public string CompanyAddress3 { get; set; }  = "1";
        public string CompanyStateId { get; set; }  = "24";
        public string CompanyStateCode { get; set; }  = "24";
        public string CompanyEmail { get; set; }  = "1";
        public string CompanyMobile { get; set; }  = "1";
        public string CompanyTelephone { get; set; }  = "1";
        public string CompanyWebsite { get; set; } = "1";
        public string CompanyFax { get; set; } = "1";
        public string CompanyPincode { get; set; } = "1";
        public string CompanyContactPerson { get; set; } = "1";
        public string CompanyCurrency { get; set; } = "1";
        public DateTime CompanyBeginningDate { get; set; } = DateTime.UtcNow.Date;
        public bool CompanyIsGstApplicable { get; set; } = true;
        public string CompanyGstApplicableFrom { get; set; } = "1";
        public string CompanyGstin { get; set; } = "1";
        public string CompanyPanNo { get; set; } = "1";
        public bool CompanyIsLutBond { get; set; } = true;
        public string CompanyLutBondNo { get; set; } = "1";
        public string CompanyLutBondTo { get; set; } = "1";
        public bool CompanyIsEWayBill { get; set; } = true;
        public string CompanyEWayBillFrom { get; set; } = "1";
        public decimal CompanyEWayBillLimit { get; set; } = 0;
        public bool CompanyIsEInvoice { get; set; } = true;
        public string CompanyEInvoiceFrom { get; set; } = "1";
       
      
   



        public string CompanyRegNo { get; set; }  = "1";
        public string CompanyCurSymbol { get; set; }  = "1";
        public string CompanyDecimal { get; set; }  = "1";
        public string CompanyDateFormat { get; set; }  = "1";
        public string CompanyRemarks { get; set; } 
        public string CompanyLogo { get; set; }  = "null";
        public string CompanyCity { get; set; }  = "1";
        public string CompanyCountry { get; set; }  = "1";
        public string CompanyTagline1 { get; set; }  = "1";
        public string CompanyTagline2 { get; set; }  = "1";
        public string CompanyMsmeNo { get; set; }  = "1";
     


    }




}
