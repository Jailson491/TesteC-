using Microsoft.EntityFrameworkCore;

namespace Santader.UserControl.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<User> User { get; set; }
        public DbSet<UserDelete> UserDelete { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-DAQPTM3\SQLEXPRESS;Initial Catalog=DW;User ID=sa;Password=1234");




    }
}
