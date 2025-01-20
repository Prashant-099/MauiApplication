using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{
    public class User
    {
        public string UserFirstName { get; set; } = "1";
        public string UserLastName { get; set; } = "1";
        public string UserEmail { get; set; } = "1";
        public string UserName { get; set; } = "1";
        public string UserPhone { get; set; } = "1";
        public string UserCountryCode { get; set; } = "1";
        public string UserMobile { get; set; } = "1";
        public bool UserStatus { get; set; } = true;
        public DateTime UserCreated { get; set; } = DateTime.UtcNow.Date;
        public DateTime UserDob { get; set; } = DateTime.UtcNow.Date;
        public int UserId { get; set; } 
        public string UserRoleName { get; set; } = "Admin";
        public string UserCompanyId { get; set; } = "1";
        public string UserAddbyUserId { get; set; } = "1";
        public string UserGender { get; set; } = "1";
        
public string UserAddress { get; set; } = "1";
        public string UserImage { get; set; } = "1";
        public string UserZipcode { get; set; } = "1";
        public string UserPassword { get; set; } = "Admin";
        public int UserParentId { get; set; } = 1;
        public string UserRoleId { get; set; } = "1";
    }

    public class UserResponse
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<User> data { get; set; } = new();
    }

}
