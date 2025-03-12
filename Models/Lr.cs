using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MauiAppFB.Models
{
    public class Lr
    {

        public int LrID { get; set; }
        public int LrNo { get; set; } = 147;
        public DateTime LrDate { get; set; } = DateTime.Now;

        //[Required(ErrorMessage = "Vehicle No is required")]
        public string Vehicle_No { get; set; }
        public string Supplier_Name { get; set; }
        public string Party_Name { get; set; }
        public string Consignor_Name { get; set; }
        public string Consignee_Name { get; set; }

        
        public string From_Location { get; set; }
        public string To_Location { get; set; }
        public string Product_Name { get; set; }
        public string Driver_Name { get; set; }
        public string Lr_Nostr { get; set; } = "1222";
        public string LrContainer1 { get; set; } = "cooo1";
        public string LrContainer2 { get; set; } = "cooo2";
        public double LoadWt { get; set; }
        public double UnloadWt { get; set; }
        public double ChargeWt { get; set; }
        public decimal Freight { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow.Date;
        public DateTime? AddedDate { get; set; } = DateTime.UtcNow.Date;

        //[JsonConverter(typeof(StringToIntConverter))]
        public string? LrNostr { get; set; }="test";
        public int LrVoucherId { get; set; } = 1;
        public int LrConsigneeNotifyId { get; set; }
        public int LrConsignorNotifyId { get; set; }
        public int LrProductId { get; set; } = 1;
        public int LrVehicleId { get; set; }
        public int LrSupplierAccountId { get; set; } = 1;
        public int LrDriverId { get; set; }
        public int LrPartyAccountId { get; set; } = 1;


        public string? LrTime { get; set; }
        public int LrTripno { get; set; }
        public int LrFromLocationId { get; set; }
        public int LrToLocationId { get; set; }
        public int? LrBackLocationId { get; set; } = 1;

        public double LrGrosswt { get; set; }
        public double LrTarewt { get; set; }
        public double LrLoadwt { get; set; }
        public double LrChargeqty { get; set; }
        public string LrPaymenttype { get; set; } = "To Be Billed To";
        public double LrRatebill { get; set; }
        public double LrBilltypebill { get; set; } = 1;
        public double LrGrossfreightbill { get; set; }
        public string LrRefby { get; set; }
        public string LrStartkm { get; set; }
        public string LrEndkm { get; set; }
        public double LrBilltypetruck { get; set; }
        public double LrBillratetruck { get; set; }
        public double LrGrossfreighttruck { get; set; }
        public string LrInvoiceno { get; set; }
        public double LrInvoicevalue { get; set; }
        public string LrInvoicedate { get; set; }
        public string LrDono { get; set; }
        public string LrDodate { get; set; }
        public string LrEwaybillno { get; set; }
        public string LrSbno { get; set; }
        public string LrRemarks { get; set; }
        public string LrReportDate { get; set; }
        public string LrReportTime { get; set; }
        public string LrUnloadDate { get; set; }
        public string LrUnloadTime { get; set; }
        public string LrPodDate { get; set; }
        public string LrReturnDate { get; set; }
        public string LrGatepassno { get; set; }
        public double LrTotkm { get; set; }
        public double LrTotalbags { get; set; }
        public string LrTriptype { get; set; }
        public string LrCustom1 { get; set; }
        public string LrCustom2 { get; set; }
        public string LrCustom3 { get; set; }
        public string LrCustom4 { get; set; }

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
