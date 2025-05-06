using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{
    public class ReportData
    {
        public int ReportDataId { get; set; }
        public string ReportDataDocType { get; set; }
        public string ReportDataLayoutData { get; set; }
        public string ReportDataFormatName { get; set; }
        public int ReportDataCompanyId { get; set; }
        public int ReportDataStatus { get; set; }
    }

}
