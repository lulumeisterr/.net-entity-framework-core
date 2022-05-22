using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Allocation = web_project_api.app.Model.Allocation;
using Trade = web_project_api.app.Model.Trade;

namespace web_project_api.app.DbContextInit;

    public class ApplicationDbContext : DbContext {
        public DbSet<Trade> Trades {get;set;}
        public DbSet<Allocation> Allocations {get;set;}
        
        public string connectingString { get; set; }

        public ApplicationDbContext(IConfiguration configuration) {
            this.connectingString = configuration["Database:sqlConnection"];
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(connectionString: $@"{this.connectingString}",
                new MySqlServerVersion(new Version(8, 0, 27)));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Ignore<Notification>();
            /** Relacionamento 1..*
               modelBuilder.Entity<Allocation>().HasOne<Trade>(allocation => allocation.Trade)
                                             .WithMany(trade => trade.Allocations)
                                             .HasForeignKey(allocation => allocation.CurrentTradeId);
            **/
        }
    }
