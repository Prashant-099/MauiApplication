using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ServiceStack.LicenseUtils;

namespace MauiAppFB.Models
{
    public class Locations
    {
        public int LocationId { get; set; } 
        public string LocationCompanyId { get; set; } = "1";
        public string LocationAddedByUserId { get; set; } = "1";
        public string LocationUpdatedByUserId { get; set; } = "1";

        [Required (ErrorMessage= "Location Name is Required.")]
        public string LocationName { get; set; }
        public string LocationPincode { get; set; } = "1";
        public string LocationState { get; set; } = "1";
        public string LocationDistrict { get; set; } = "1";
        public bool LocationStatus { get; set; } = true;
        public DateTime LocationCreated { get; set; } = DateTime.UtcNow.Date;
        public DateTime LocationUpdated { get; set; } = DateTime.UtcNow.Date;
        public string LocationCode { get; set; }
        public int LocationCountryId { get; set; } = 1;
        public string LocationType { get; set; } 

    }
    public class LocationResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<Locations> locations { get; set; } = new();

    }
    
    }
