using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.UI;
using System.IO;
namespace MauiAppFB.Services
{
    
    public class Reportservice
    {

        public static byte[] GenerateChallanReportPdf()
        {
            string reportPath = Path.Combine(AppContext.BaseDirectory, "Reports", "ChallanReport.repx");
            XtraReport report = XtraReport.FromFile(reportPath, true);

            using var ms = new MemoryStream();
            report.ExportToPdf(ms);
            return ms.ToArray();
        }
    }

}