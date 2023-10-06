using Microsoft.EntityFrameworkCore;
using ReportApplication.Models;

namespace ReportApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            this.Database.EnsureCreated();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetails> ReportDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportDetails>()
                .HasOne(er => er.Report)
                .WithMany(r => r.ReportDetails)
                .HasForeignKey(er => er.ReportId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
