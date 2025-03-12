using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{
    public class Paytype
    {
        public int PayTypeId { get; set; }
        public string PayTypeCompanyId { get; set; }
        public string PayTypeAddedByUserId { get; set; }

        public string PayTypeUpdatedByUserId { get; set; }
        public string PayTypeName { get; set; }
        public bool PayTypeStatus { get; set; }

    }
    public class PaytypeResponse {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<Paytype> payTypes { get; set; } = new();
    }
}
