using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MauiAppFB.Models
{
    public class Lr
    {

        public int LrID { get; set; }
        public int LrNo { get; set; }
        public DateTime LrDate { get; set; } = DateTime.Now;


        public string Vehicle_No { get; set; }
        public string Supplier_Name { get; set; }
        public string Party_Name { get; set; }

        public string Consignor_Name { get; set; }
        public string Consignee_Name { get; set; }


        public string From_Location { get; set; }

        public string To_Location { get; set; }
        public string Product_Name { get; set; }
        public string Driver_Name { get; set; }
        public string? Lr_Nostr { get; set; }
        public string? LrContainer1 { get; set; }
        public string? LrContainer2 { get; set; }
        public double? LoadWt { get; set; } = 0;
        public double? LrUnloadWt { get; set; } = 0;
        public double? ChargeWt { get; set; }
        public decimal? Freight { get; set; }
        public decimal? Advance { get; set; }
        public decimal? OtherExpenses { get; set; } = 0;
        public decimal? Net { get; set; }
        //public string AddedBy { get; set; } 
        //public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow.Date;
        public DateTime? AddedDate { get; set; } = DateTime.UtcNow.Date;

        //[JsonConverter(typeof(StringToIntConverter))]
        public string? LrNostr { get; set; }
        public int LrVoucherId { get; set; } = 1;
        public int LrConsigneeNotifyId { get; set; }
        public int LrConsignorNotifyId { get; set; }
        public int LrProductId { get; set; }
        [Required(ErrorMessage = "Vehicle No is required")]
        public int LrVehicleId { get; set; }
        public int LrSupplierAccountId { get; set; } = 0;
        public int LrDriverId { get; set; } = 1;
        public int? LrPartyAccountId { get; set; }


        public string? LrTime { get; set; }
        public int? LrTripno { get; set; } = 0;
        [Required(ErrorMessage = "From Location is required.")]
        public int LrFromLocationId { get; set; }
        [Required(ErrorMessage = "To Location is required.")]
        public int LrToLocationId { get; set; }
        public int? LrBackLocationId { get; set; } = 0;

        public double? LrGrosswt { get; set; } = 0;
        public double? LrTarewt { get; set; } = 0;
        public double? LrLoadwt { get; set; } = 0;
        public double LrChargeqty { get; set; } = 0;
        public string LrPaymenttype { get; set; }
        public double? LrRatebill { get; set; } = 0;
        public double? LrBilltypebill { get; set; } = 0;
        public decimal? LrGrossfreightbill { get; set; } = 0;
        public decimal? LrNetfreightbill { get; set; } = 0;
        public decimal? LrAdvancebill { get; set; } = 0;
        public decimal? LrOtherChargebill { get; set; } = 0;
        public string? LrRefby { get; set; }
        public string? LrStartkm { get; set; }
        public string? LrEndkm { get; set; }
        public double? LrBilltypetruck { get; set; } = 0;
        public double? LrBillratetruck { get; set; } = 0;
        public double LrGrossfreighttruck { get; set; } = 0;
        public string? LrInvoiceno { get; set; }
        public double? LrInvoicevalue { get; set; } = 0;
        public string? LrInvoicedate { get; set; }
        public string? LrDono { get; set; }
        public string? LrDodate { get; set; }
        public string? LrEwaybillno { get; set; }
        public string? LrSbno { get; set; }
        public string? LrRemarks { get; set; }
        public string? LrReportDate { get; set; }
        public string? LrReportTime { get; set; }
        public string? LrUnloadDate { get; set; }
        public string? LrUnloadTime { get; set; }
        public string? LrPodDate { get; set; }
        public string? LrReturnDate { get; set; }
        public string? LrGatepassno { get; set; }
        public double LrTotkm { get; set; } = 0;
        public double? LrTotalbags { get; set; } = 0;
        public string LrTriptype { get; set; } = "0";
        public string? LrCustom1 { get; set; }
        public string? LrCustom2 { get; set; }
        public string? LrCustom3 { get; set; }
        public string? LrCustom4 { get; set; }

        public string? LrDriverName { get; set; }
        public string? LrDriverMobile { get; set; }
        public DateTime? LrEwaybillExpdt { get; set; }
        public string? LrConsigneeName { get; set; }
        public string? LrConsigneeAddress { get; set; }
        public string? LrConsigneeGstin { get; set; }
        public string? LrConsignorGstin { get; set; }
        public string? LrConsignorName { get; set; }
        public string? LrConsignorAddress { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyTitle { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyGSTIN { get; set; }
        public string? CompanyPan { get; set; }
        public string? CompanyMSME { get; set; }



    }

    public class LRResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<Lr> challans { get; set; } = new();
    }
}
