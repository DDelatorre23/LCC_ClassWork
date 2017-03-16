using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CommunityWebSite.Models
{
    public class  User : IdentityUser
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
