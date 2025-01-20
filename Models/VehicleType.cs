using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string VehicleTypeCompanyId { get; set; } = string.Empty;
        public string VehicleTypeAddByUserId { get; set; } = string.Empty;
        public string VehicleTypeUpdatedByUserId { get; set; } = string.Empty;
        public string VehicleTypeName { get; set; } = string.Empty;
        public int VehicleTypeStatus { get; set; }
        public DateTime VehicleTypeCreated { get; set; }
        public DateTime VehicleTypeUpdated { get; set; }
        public string VehicleTypeDesc { get; set; } = string.Empty;
        public int VehicleTypeCapacity { get; set; }


    }
    public class VehicleTypeResponse
    {
        public List<VehicleType> VehicleTypes { get; set; } = new();
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }


}
