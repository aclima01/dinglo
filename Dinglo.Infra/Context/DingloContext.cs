using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Account;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Infra.Context
{
    public class DingloContext : IdentityDbContext<UserIdentity>
    {

     public DingloContext(DbContextOptions<DingloContext> options)
            : base(options)
        { }

        public DingloContext()
        { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppVersion> AppVersions { get; set; }

        public DbSet<CustAccount> CustAccounts { get; set; }
        public DbSet<CustContact> CustContacts { get; set; }
        public DbSet<CustAddress> CustAddresses { get; set; }
        public DbSet<AGRO_HerdManager> AGRO_HerdManagers { get; set; }
        public DbSet<AGRO_HerdManager_Breed> AGRO_HerdManager_Breeds { get; set; }
        public DbSet<AGRO_HerdManager_DeathCause> AGRO_HerdManager_DeathCauses { get; set; }
        public DbSet<AGRO_HerdManager_Drug> AGRO_HerdManager_Drugs { get; set; }
        public DbSet<AGRO_HerdManager_Expense> AGRO_HerdManager_Expenses { get; set; }
        public DbSet<AGRO_HerdManager_HealthRating> AGRO_HerdManager_HealthRatings { get; set; }
        public DbSet<AGRO_HerdManager_Origin> AGRO_HerdManager_Origins { get; set; }
        public DbSet<AGRO_HerdManager_Pasture> AGRO_HerdManager_Pastures { get; set; }
        public DbSet<AGRO_HerdManager_Status> AGRO_HerdManager_Status { get; set; }
        public DbSet<AGRO_HerdManager_Type> AGRO_HerdManager_Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DingloContext).Assembly);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("Dinglo");
                optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Dinglo.Infra"));
            }
        }
    }
}