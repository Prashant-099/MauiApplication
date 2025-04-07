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
                using Stream stream = await FileSystem.OpenAppPackageFileAsync("Components/Reports/ChallanReport.repx");
                var report = new XtraReport();
                report.LoadLayoutFromXml(stream);
                return report;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading report: {ex.Message}");
                return null;
            }
        }
    }

}