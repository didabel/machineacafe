using Microsoft.EntityFrameworkCore;

namespace MachineCafeApi.Models
{
    public class CommandeContext : DbContext 
    {
        public CommandeContext(DbContextOptions<CommandeContext> options) : base (options)
        {
        }

        public virtual DbSet<Commande> Commandes { get; set; }
    }
}


/*
 * 
 * using Microsoft.EntityFrameworkCore;

namespace SkypeLocation.WebApi.ViewModels.Dal
{
    public class PositionLearningContext : DbContext
    {
        public PositionLearningContext(DbContextOptions<PositionLearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InfoLearning> InfoLearning { get; set; }
        public virtual DbSet<InfoPositions> InfoPositions { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfoLearning>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LearnModel)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<InfoPositions>(entity =>
            {
                entity.Property(e => e.Bssid1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Bssid2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Bssid3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Bssid4)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ssid1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ssid2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ssid3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ssid4)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}

*/
