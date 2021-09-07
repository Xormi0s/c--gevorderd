using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Les6Oefening
{
    public partial class AirplanesDbContext : DbContext
    {
        public AirplanesDbContext()
        {
        }

        public AirplanesDbContext(DbContextOptions<AirplanesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airplane> Airplane { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:airplanesoef.database.windows.net,1433;Initial Catalog=AirplanesDb;Persist Security Info=False;User ID=r0425410;Password=Noobcake1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.HasKey(e => e.FlightCode)
                    .HasName("PK__Airplane__75575F50E2456C8E");

                entity.Property(e => e.FlightCode).HasMaxLength(10);

                entity.Property(e => e.Maintenance)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
