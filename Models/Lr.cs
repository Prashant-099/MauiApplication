using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{
    public class Lr
    {
        public int LRId { get; set; }




        public int? LrCompanyId { get; set; } = 1;
            public int? LrAddedByUserId { get; set; } = 1;
        public int? LrVoucherId { get; set; } = 1;
        public int? LrPartyAccountId { get; set; } = 1;
        public int?  LrConsigneeNotifyId { get; set; } = 1;
        public int? LrConsignorNotifyId { get; set; } = 1;
        public int? LrProductId { get; set; } = 1;
        public int? LrVehicleId { get; set; } = 1;
        public int? LrSupplierAccountId { get; set; } = 1;
        public int? LrDriverId { get; set; } = 1;
        public int? LrNo { get; set; } = 1;
        public string? LrNostr { get; set; } = "1";
        public DateTime? LrDate { get; set; } = DateTime.UtcNow.Date;
        public string? LrTime { get; set; } = "12";
        public int? LrTripno { get; set; } = 1;
            public int? LrFromLocationId { get; set; } = 1;
        public int? LrToLocationId { get; set; } = 1;
        public int? LrBackLocationId { get; set; } = 1;
        public string? LrContainer1 { get; set; } = "1";
        public string? LrContainer2 { get; set; } = "1";
            public double? LrGrosswt { get; set; } = 1.5;
        public double? LrTarewt { get; set; } = 1.5;
        public double? LrLoadwt { get; set; } = 55;
        public double? LrChargeqty { get; set; } = 1.5;
        public double? LrUnloadwt { get; set; } = 1.5;
        public double? LrShortwt { get; set; } = 1.5;
        public double? LrShortallowBill { get; set; } = 1.5;
        public double? LrShortPerBill { get; set; } = 1.5;
        public double? LrShortPerTruck { get; set; } = 1.5;
        public string? LrShortallowtype { get; set; } = "1";
            public double? LrShortnetBill { get; set; } = 1.5;
        public double? LrShortratebill { get; set; } = 1.5;
        public double? LrShortratetruck { get; set; } = 1.5;
        public double? LrShortamtbill { get; set; } = 1.5;
        public double? LrShortamttruck { get; set; } = 1.5;
        public string? LrPaymenttype { get; set; } = "1";
        public double? LrRatebill { get; set; } = 1.5;
        public double? LrBilltypebill { get; set; } = 1.5;
        public double? LrGrossfreightbill { get; set; } = 1.5;
        public double? LrTripchargebill { get; set; } = 1.5;
        public double? LrAdvancebill { get; set; } = 1.5;
        public double LrNetfreightbill { get; set; } = 1.5;
        public string? LrRefby { get; set; } = "1";
        public string? LrStartkm { get; set; } = "1";
        public string? LrEndkm { get; set; } = "1";
            public double? LrBilltypetruck { get; set; } = 1.5;
        public double? LrBillratetruck { get; set; } = 1.5;
        public double? LrGrossfreighttruck { get; set; } = 1.5;
        public double? LrTripchargetruck { get; set; } = 1.5;
        public double? LrTripadvance { get; set; } = 1.5;
        public double? LrCashbank { get; set; } = 1.5;
        public double? LrNetfreighttruck { get; set; } = 1.5;
        public string? LrCustom1 { get; set; } = "1";
            public string? LrCustom2 { get; set; } = "1";
        public string? LrCustom3 { get; set; } = "1";
        public string? LrCustom4 { get; set; } = "1";
        public string? LrInvoiceno { get; set; } = "1";
        public double? LrInvoicevalue { get; set; } = 1.5;
            public string? LrInvoicedate { get; set; } = "1";
        public string? LrDono { get; set; } = "1";
        public string? LrDodate { get; set; } = "1";
        public string? LrEwaybillno { get; set; } = "1";
        public string? LrSbno { get; set; } = "1";
        public string? LrRemarks { get; set; } = "1";
        public string? LrReportDate { get; set; } = "1";
        public string? LrReportTime { get; set; } = "1";
        public string? LrUnloadDate { get; set; } = "1";
        public string? LrUnloadTime { get; set; } = "1";
        public string? LrPodDate { get; set; } = "1";
        public string? LrReturnDate { get; set; } = "1";
        public double? LrDetentionRatebill { get; set; } = 1.5;
        public double? LrDetentionRatetruck { get; set; } = 1.5;
        public double? LrDetentionDaybill { get; set; } = 1.5;
        public double? LrDetentionDaytruck { get; set; } = 1.5;
        public double? LrDetentionAmtbill { get; set; } = 1.5;
        public double? LrDetentionAmttruck { get; set; } = 1.5;
        public string? LrApprovedBy { get; set; } = "1";
        public int? LrChaId { get; set; } = 1;
        public int? LrVesselId { get; set; } = 1;
            public string? LrGatepassno { get; set; } = "1";
        public int? LrPartyBillId { get; set; } = 1;
            public int? LrSupplierBillId { get; set; } = 1;
        public int? LrAllowancePayId { get; set; } = 1;
        public int? LrAdvancePayId { get; set; } = 1;
        public int? LrAdvanceRecId { get; set; } = 1;
        public double? LrTotkm { get; set; } = 1.5;
        public double? LrTotalbags { get; set; } = 1.5;
        public string? LrTriptype { get; set; } = "1";
        public string? LrGroupno { get; set; } = "1";
            public double? LrAllowAmt { get; set; } = 1.5;
        public double? LrAllowDieselQty { get; set; } = 1.5;




        public DateTime? ewaybilldate { get; set; } = DateTime.UtcNow.Date;




    }

public class LRResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<Lr> Records { get; set; } = new();
    }
}
