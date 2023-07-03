using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NewShoreAir.Domain;
using NewShoreAir.Domain.Common;

namespace NewShoreAir.Infrastructure.Persistence
{
    public class NewShoreAirDbContext : DbContext
    {
        public NewShoreAirDbContext(DbContextOptions<NewShoreAirDbContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Flight

            modelBuilder.Entity<Flight>()
               .HasOne(x => x.Transport)
               .WithMany(x => x.Flights)
               .HasForeignKey(x => x.TransportId)
               .HasConstraintName("FK_Flight_TransportId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasIndex(x => x.Origin)
                .HasDatabaseName("IX_Flight_Origin");

            modelBuilder.Entity<Flight>()
                .HasIndex(x => x.Destination)
                .HasDatabaseName("IX_Flight_Destination");

            #endregion

            #region JourneyFlight          

            modelBuilder.Entity<Journey>()
               .HasMany(m => m.Flights)
               .WithMany(m => m.Journeys)
               .UsingEntity<JourneyFlight>(
                    x => x
                    .HasOne(y => y.Flight)
                    .WithMany(y => y.JourneyFlights)
                    .HasForeignKey(y => y.FlightId)
                    .HasConstraintName("FK_JourneyFlight_FlightId")
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict),
                    x => x
                    .HasOne(y => y.Journey)
                    .WithMany(y => y.JourneyFlights)
                    .HasForeignKey(y => y.JourneyId)
                    .HasConstraintName("FK_JourneyFlight_JourneyId")
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict)                   
                );

            #endregion



        }

        public DbSet<Journey> Journey { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<JourneyFlight> JourneyFlights { get; set; }
        public DbSet<Transport> Transport { get; set; }


    }
}
