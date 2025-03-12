using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MauiAppFB.Models
{
    public class Vehicles
    {


        public int VehicleId { get; set; }

        public int VehicleCompanyId { get; set; } = 1;

        public int VehicleAddByUserId { get; set; } = 1;

        public int? VehicleUpdatedByUserId { get; set; }

        public string VehicleNo { get; set; }

        public string VehicleOwnerType { get; set; } = "Yes";

        public int VehicleAccountId { get; set; } = 0;

        public int? VehicleTypeId { get; set; } = 0;

        public int? VehicleGroupId { get; set; } = 0;

        public int? VehicleAverage { get; set; }

        public string? VehicleRTO { get; set; } = "";

        public string? VehicleEngineNo { get; set; } = "";

        public string? VehicleChassisNo { get; set; } = "";

        public double? VehicleLoadCapacity { get; set; }

        public string? VehicleMake { get; set; } = "";

        public string? VehicleModel { get; set; } = "";

        public string? VehicleRemarks { get; set; } = "ok";

        public int VehicleStatus { get; set; } = 0;

        public string? VehicleFastage { get; set; } = "";

        public string? VehicleGpsNo { get; set; } = "";

        public DateTime? VehicleCreated { get; set; } = DateTime.UtcNow.Date;

        public DateTime? VehicleUpdated { get; set; } = DateTime.UtcNow.Date;

        public DateTime? VehicleTax { get; set; } = DateTime.UtcNow.Date;

        public DateTime? VehicleFitness { get; set; } = DateTime.UtcNow.Date;

        public DateTime? VehicleStatePermit { get; set; } = DateTime.UtcNow.Date;

        public DateTime? VehicleNational { get; set; } = DateTime.UtcNow.Date;

        public DateTime? VehicleInsurance { get; set; } = DateTime.UtcNow.Date;

        public DateTime? VehiclePUC { get; set; } = DateTime.UtcNow.Date;

        public DateTime? VehicleForm9 { get; set; } = DateTime.UtcNow.Date;

        public DateTime? VehicleCalibration { get; set; } = DateTime.UtcNow.Date;

        public DateTime? VehicleEMI { get; set; } = DateTime.UtcNow.Date;

        public int? VehicleDriverId { get; set; }
    }

    public class VehicleResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<Vehicles> vehicles { get; set; } = new();

    }



}


