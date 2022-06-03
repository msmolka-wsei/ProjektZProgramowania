using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZProgramowania.Enities
{
    public class ApplicationUser : IdentityUser
    {
        public long? UserId { get; set; }
        public User? User { get; set; }
    }
}
