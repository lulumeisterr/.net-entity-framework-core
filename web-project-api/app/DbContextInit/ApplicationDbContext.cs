using Microsoft.EntityFrameworkCore;
using web_project_api.app.Model;

namespace web_project_api.app.DbContextInit;

    public class ApplicationDbContext : DbContext {
        public DbSet<Trade> Trades {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseMySQL("server=127.0.0.1;user=root;password=1234;database=trades");
    }
