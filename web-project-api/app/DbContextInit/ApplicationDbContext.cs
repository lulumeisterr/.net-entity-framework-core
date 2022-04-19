using Microsoft.EntityFrameworkCore;
using Allocation = web_project_api.app.Model.Allocation;
using Trade = web_project_api.app.Model.Trade;

namespace web_project_api.app.DbContextInit;

    public class ApplicationDbContext : DbContext {
        public DbSet<Trade> Trades {get;set;}
        public DbSet<Allocation> Allocations {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(connectionString: @"Server=localhost;User=root;Password=ANSKk08aPEDbFjDO;Database=testing",
                new MySqlServerVersion(new Version(8, 0, 27)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            /** Relacionamento 1..*
               modelBuilder.Entity<Allocation>().HasOne<Trade>(allocation => allocation.Trade)
                                             .WithMany(trade => trade.Allocations)
                                             .HasForeignKey(allocation => allocation.CurrentTradeId);
            **/
        }
    }
