using CrudOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Data
{
    public class EmployeeDbcontext:DbContext
    {
        public EmployeeDbcontext(DbContextOptions<EmployeeDbcontext>options):base(options)
        {

        }
       public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
