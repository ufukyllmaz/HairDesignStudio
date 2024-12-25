using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HairDesginStudio.Models
{
    public class AdvanceUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}