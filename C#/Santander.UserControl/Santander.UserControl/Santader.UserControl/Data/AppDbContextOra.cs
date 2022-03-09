using Microsoft.EntityFrameworkCore;
using Santader.UserControl.Models;

namespace Santader.UserControl.Data
{
    public class AppDbContextOra : DbContext
    {
        public DbSet<DeleteUsers> DeleteUsers { get; set; }

        protected override void OnConfiguring(
          DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseOracle("User Id=SYSTEM;Password=4911;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)))");
    }
}
