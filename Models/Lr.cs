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
       


      
            public int? LrCompanyId { get; set; }
            public int? LrAddedByUserId { get; set; }
            public int? LrVoucherId { get; set; }
            public int? LrPartyAccountId { get; set; }
            public int?  LrConsigneeNotifyId { get; set; }
            public int? LrConsignorNotifyId { get; set; }
            public int? LrProductId { get; set; }
            public int? LrVehicleId { get; set; }
            public int? LrSupplierAccountId { get; set; }
            public int? LrDriverId { get; set; }
            public int? LrNo { get; set; }
            public string? LrNostr { get; set; }
        public DateTime? LrDate { get; set; } = DateTime.UtcNow.Date;
            public string? LrTime { get; set; }
            public int? LrTripno { get; set; }
            public int? LrFromLocationId { get; set; }
            public int? LrToLocationId { get; set; }
            public int? LrBackLocationId { get; set; }
            public string? LrContainer1 { get; set; }
            public string? LrContainer2 { get; set; }
            public double? LrGrosswt { get; set; }
            public double? LrTarewt { get; set; }
            public double? LrLoadwt { get; set; }
            public double? LrChargeqty { get; set; }
            public double? LrUnloadwt { get; set; }
            public double? LrShortwt { get; set; }
            public double? LrShortallowBill { get; set; }
            public double? LrShortPerBill { get; set; }
            public double? LrShortPerTruck { get; set; }
            public string? LrShortallowtype { get; set; }
            public double? LrShortnetBill { get; set; }
            public double? LrShortratebill { get; set; }
            public double? LrShortratetruck { get; set; }
            public double? LrShortamtbill { get; set; }
            public double? LrShortamttruck { get; set; }
            public string? LrPaymenttype { get; set; }
            public double? LrRatebill { get; set; }
            public double? LrBilltypebill { get; set; }
            public double? LrGrossfreightbill { get; set; }
            public double? LrTripchargebill { get; set; }
            public double? LrAdvancebill { get; set; }
            public double LrNetfreightbill { get; set; }
            public string? LrRefby { get; set; }
            public string? LrStartkm { get; set; }
            public string? LrEndkm { get; set; }
            public double? LrBilltypetruck { get; set; }
            public double? LrBillratetruck { get; set; }
            public double? LrGrossfreighttruck { get; set; }
            public double? LrTripchargetruck { get; set; }
            public double? LrTripadvance { get; set; }
            public double? LrCashbank { get; set; }
            public double? LrNetfreighttruck { get; set; }
            public string? LrCustom1 { get; set; }
            public string? LrCustom2 { get; set; }
            public string? LrCustom3 { get; set; }
            public string? LrCustom4 { get; set; }
            public string? LrInvoiceno { get; set; }
            public double? LrInvoicevalue { get; set; }
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
            public double? LrDetentionRatebill { get; set; }
            public double? LrDetentionRatetruck { get; set; }
            public double? LrDetentionDaybill { get; set; }
            public double? LrDetentionDaytruck { get; set; }
            public double? LrDetentionAmtbill { get; set; }
            public double? LrDetentionAmttruck { get; set; }
            public string? LrApprovedBy { get; set; }
            public int? LrChaId { get; set; }
            public int? LrVesselId { get; set; }
            public string? LrGatepassno { get; set; }
            public int? LrPartyBillId { get; set; }
            public int? LrSupplierBillId { get; set; }
            public int? LrAllowancePayId { get; set; }
            public int? LrAdvancePayId { get; set; }
            public int? LrAdvanceRecId { get; set; }
            public double? LrTotkm { get; set; }
            public double? LrTotalbags { get; set; }
            public string? LrTriptype { get; set; }
            public string? LrGroupno { get; set; }
            public double? LrAllowAmt { get; set; }
            public double? LrAllowDieselQty { get; set; }




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
