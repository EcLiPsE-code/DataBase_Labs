using Company.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class UserIdentity : IdentityUser
    {
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}
