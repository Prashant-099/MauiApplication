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
        public static async Task<XtraReport?> LoadChallanReportAsync()
        {
            try
            {                                                 
                var assembly = typeof(Reportservice).Assembly;
                var resourceName = "MauiAppFB.Components.Reports.ChallanReport.repx"; // Match this to your actual namespace + folder

                using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    Console.WriteLine($"[ERROR] Report not found: {resourceName}");
                    return null;
                }

                return XtraReport.FromStream(stream, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] LoadChallanReportAsync: {ex.Message}");
                return null;
            }

        }
    }
}