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


        [JsonPropertyName("vehicleId")]
        public int VehicleId { get; set; }

        [JsonPropertyName("vehicleCompanyId")]
        public int? VehicleCompanyId { get; set; } = 1;

        [JsonPropertyName("vehicleAddByUserId")]
        public int? VehicleAddByUserId { get; set; } = 1;

        [JsonPropertyName("vehicleUpdatedByUserId")]
        public int? VehicleUpdatedByUserId { get; set; } = 1;

        [JsonPropertyName("vehicleNo")]
        public string? VehicleNo { get; set; } 

        [JsonPropertyName("vehicleOwnerType")]
        public string? VehicleOwnerType { get; set; }

        [JsonPropertyName("vehicleAccountId")]
        public int? VehicleAccountId { get; set; } = 1;

        [JsonPropertyName("vehicleTypeId")]
        public int? VehicleTypeId { get; set; } = 1;

        [JsonPropertyName("vehicleGroupId")]
        public int? VehicleGroupId { get; set; } = 1;

        [JsonPropertyName("vehicleAverage")]
        public int? VehicleAverage { get; set; } = 0;

        [JsonPropertyName("vehicleRTO")]
        public string? VehicleRTO { get; set; } 

        [JsonPropertyName("vehicleEngineNo")]
        public string? VehicleEngineNo { get; set; } = "test";

        [JsonPropertyName("vehicleChassisNo")]
        public string? VehicleChassisNo { get; set; } = "test";

        [JsonPropertyName("vehicleLoadCapacity")]
        public double? VehicleLoadCapacity { get; set; } = 1.1;

        [JsonPropertyName("vehicleMake")]
        public string? VehicleMake { get; set; } = "test";

        [JsonPropertyName("vehicleModel")]
        public string? VehicleModel { get; set; } = "test";

        [JsonPropertyName("vehicleRemarks")]
        public string? VehicleRemarks { get; set; } = "test";

        [JsonPropertyName("vehicleStatus")]
        public int? VehicleStatus { get; set; } = 1;

        [JsonPropertyName("vehicleFastage")]
        public string? VehicleFastage { get; set; } = "test";

        [JsonPropertyName("vehicleGpsNo")]
        public string? VehicleGpsNo { get; set; } = "test";

        [JsonPropertyName("vehicleCreated")]
        public DateTime? VehicleCreated { get; set; } = DateTime.UtcNow.Date;

        [JsonPropertyName("vehicleUpdated")]
        public DateTime? VehicleUpdated { get; set; } = DateTime.UtcNow.Date;

        [JsonPropertyName("vehicleTax")]
        public DateTime? VehicleTax { get; set; } = DateTime.UtcNow.Date;

        [JsonPropertyName("vehicleFitness")]
        public DateTime? VehicleFitness { get; set; } = DateTime.UtcNow.Date;

        [JsonPropertyName("vehicleStatePermit")]
        public DateTime? VehicleStatePermit { get; set; } = DateTime.UtcNow.Date;

        [JsonPropertyName("vehicleNational")]
        public DateTime? VehicleNational { get; set; } = DateTime.UtcNow.Date;

            [JsonPropertyName("vehicleInsurance")]
        public DateTime? VehicleInsurance { get; set; }= DateTime.UtcNow.Date;

            [JsonPropertyName("vehiclePUC")]
        public DateTime? VehiclePUC { get; set; } = DateTime.UtcNow.Date;

        [JsonPropertyName("vehicleForm9")]
        public DateTime? VehicleForm9 { get; set; } = DateTime.UtcNow.Date;

        [JsonPropertyName("vehicleCalibration")]
        public DateTime? VehicleCalibration { get; set; } = DateTime.UtcNow.Date;

        [JsonPropertyName("vehicleEMI")]
        public DateTime? VehicleEMI { get; set; } = DateTime.UtcNow.Date;

        [JsonPropertyName("vehicleDriverId")]
        public int? VehicleDriverId { get; set; } = 1;
    }

    public class VehicleResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        [JsonPropertyName("Vehicles")]
        public List<Vehicles> vehicles { get; set; } = new();

    }



}


