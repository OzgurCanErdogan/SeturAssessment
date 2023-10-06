using ContactApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ContactApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            this.Database.EnsureCreated();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }


        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetails> ReportDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInformation>()
                .HasOne(c => c.Person)
                .WithMany(p => p.ContactInformation)
                .HasForeignKey(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReportDetails>()
                .HasOne(er => er.Report)
                .WithMany(r => r.ReportDetails)
                .HasForeignKey(er => er.ReportId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
