using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZProgramowania.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args = null)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>();
        options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=Test; User Id=sa; Password=Zaq12wsx;Trusted_Connection=True;");
        return new ApplicationDbContext(options.Options);
    }
    }
}
