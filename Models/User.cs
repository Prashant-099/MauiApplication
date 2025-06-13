using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{
    public class User
    {
        public string UserFirstName { get; set; } 
        public string UserLastName { get; set; } 
        public string UserEmail { get; set; }
        public string UserName  => $"{UserFirstName}{UserLastName}".Trim();
        public string UserPhone { get; set; } 
        public string UserCountryCode { get; set; } = "1";
        public string UserMobile => UserPhone.Trim();
        public bool UserStatus { get; set; } = true;
        public DateTime UserCreated { get; set; } = DateTime.UtcNow.Date;
        public DateTime UserDob { get; set; } = DateTime.UtcNow.Date;
        public int UserId { get; set; }
        public string UserRoleName { get; set; } = "rolename";
        public string UserCompanyId { get; set; } = "1"; 
        public string UserAddbyUserId { get; set; } = "1";
        public string UserGender { get; set; } 

        public string UserAddress { get; set; }
        public string UserImage { get; set; } = "userimage";
        public string UserZipcode { get; set; } = "Zipcode";
        public string UserPassword { get; set; } 
        public int UserParentId { get; set; } = 1;
        public string UserRoleId { get; set; }
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
