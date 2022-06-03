using Microsoft.AspNet.Identity;
using ProjektZProgramowania.Data;
using ProjektZProgramowania.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZProgramowania.Identity
{
    public class ApplicationUserManager
    {
            
        public ApplicationUserManager(IUserStore<ApplicationUser, string> store)
            : base(store)
        {

        }

    }

}
