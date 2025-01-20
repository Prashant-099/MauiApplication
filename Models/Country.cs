using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryCompanyId { get; set; } = "1";
        public string CountryAddedByUserId { get; set; } = "1";
        public string? CountryUpdatedByUserId { get; set; } = "1";
        public string CountryName { get; set; }
        public string CountryCode { get; set; } 
        public string CountryCurrency { get; set; } ="test";
        public string? CountryRemarks { get; set; }
        public bool CountryStatus { get; set; } = true;
        public DateTime CountryCreated { get; set; } = DateTime.UtcNow.Date;
        public DateTime CountryUpdated { get; set; } = DateTime.UtcNow.Date;
    }
   
    public class CountryResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<Country> Countries { get; set; } = new();
       
    }

}
