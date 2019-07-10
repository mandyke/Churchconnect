
using ChurchConnectLite.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChurchConnectLite.Data.Data
{
    public class ChurchContext :IdentityDbContext<ApplicationUser>
    {
        public ChurchContext(DbContextOptions<ChurchContext> options)
            : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Minister> Ministers { get; set; }
        public DbSet<MainMinister> MainMinisters { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Denomination> Denominations { get; set; }
        public DbSet<Church> Churches { get; set; }
        public DbSet<ChurchSize> ChurchSizes { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
