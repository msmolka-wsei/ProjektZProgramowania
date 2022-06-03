using Microsoft.AspNet.Identity.EntityFramework;
using ProjektZProgramowania.Data;
using ProjektZProgramowania.Enities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZProgramowania.Identity
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {

            public ApplicationUserStore(DbContext context) : base(context)
            {
            }
        
    }
}
