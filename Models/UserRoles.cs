using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{
    public class UserRoles
    {
        public string RoleUuid { get; set; } = string.Empty;
        public string RoleCompanyId { get; set; } = "1";
        public string RoleAddedByUserId { get; set; } = "1";
        public string RoleUpdatedByUserId { get; set; } = "1";
        public string RoleName { get; set; } 
        public int RoleStatus { get; set; } = 1;
        public DateTime RoleCreated { get; set; } = DateTime.UtcNow.Date;
        public DateTime RoleUpdated { get; set; } = DateTime.UtcNow.Date;
        }
    public class UserRolesResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<UserRoles> roles { get; set; } = new();
    }

}
