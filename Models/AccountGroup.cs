using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{
    public class AccountGroup
    {
        public int AccountGroupId { get; set; }
        public string AccountGroupName { get; set; } = string.Empty;
        public string AccountGroupParent { get; set; } = string.Empty;
        public bool AccountTypeStatus { get; set; }
    }

    public class AccountGroupResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<AccountGroup> AccountGroups { get; set; } = new();

    }
}
