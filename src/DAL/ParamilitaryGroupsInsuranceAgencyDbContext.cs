using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    /// <summary>
    /// DbContext for Paramilitary Groups Insurance Agency
    /// </summary>
    public class ParamilitaryGroupsInsuranceAgencyDbContext : DbContext
    {
        //private readonly string connectionString = "Server=tcp:localhost;UID=SA;PWD=;Initial Catalog=ParamilitaryDb";
        /*private readonly string connectionString =
        "Server=(localdb)\\mssqllocaldb; Initial Catalog = ParamilitaryDb";
        */

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<BackgroundInfo> BackgroundInfos { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientConnection> ClientConnections { get; set; }

        public DbSet<ClientInsurance> ClientInsurances { get; set; }

        public DbSet<Conflict> Conflicts { get; set; }

        public DbSet<ConflictInvolvement> ConflictInvolvements { get; set; }

        public DbSet<ConflictRecord> ConflictRecords { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Gear> Gears { get; set; }

        public DbSet<InsuranceAgent> InsuranceAgents { get; set; }

        public DbSet<InsuranceOffer> InsuranceOffers { get; set; }

        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Constructs the context based on given options
        /// </summary>
        public ParamilitaryGroupsInsuranceAgencyDbContext(
            DbContextOptions<ParamilitaryGroupsInsuranceAgencyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Overrides model creation.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.HasOne(e => e.Administrator)
                        .WithOne(p => p.User)
                        .HasForeignKey<Administrator>(p => p.Id)
                        .OnDelete(DeleteBehavior.ClientCascade);

                    entity.HasOne(e => e.Director)
                        .WithOne(p => p.User)
                        .HasForeignKey<Director>(p => p.Id)
                        .OnDelete(DeleteBehavior.ClientCascade);

                    entity.HasOne(e => e.InsuranceAgent)
                        .WithOne(p => p.User)
                        .HasForeignKey<InsuranceAgent>(p => p.Id)
                        .OnDelete(DeleteBehavior.ClientCascade);

                    entity.HasOne(e => e.Client)
                        .WithOne(p => p.User)
                        .HasForeignKey<Client>(p => p.Id)
                        .OnDelete(DeleteBehavior.ClientCascade);
                }
            );

            modelBuilder.Entity<Administrator>(entity =>
                {
                    entity.HasKey(e => e.Id);
                }
            );

            modelBuilder.Entity<InsuranceAgent>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.HasMany(e => e.Clients)
                        .WithOne(p => p.InsuranceAgent)
                        .HasForeignKey(e => e.InsuranceAgentId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);
                }
            );

            modelBuilder.Entity<Client>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.HasMany(e => e.ObjectConnections)
                        .WithOne(p => p.Object)
                        .HasForeignKey(p => p.ObjectId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.ClientCascade);

                    entity.HasMany(e => e.SubjectConnections)
                        .WithOne(p => p.Subject)
                        .HasForeignKey(p => p.SubjectId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.ClientCascade);

                    entity.HasMany(e => e.BackgroundInfos)
                        .WithOne(p => p.Client)
                        .HasForeignKey(p => p.ClientId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

                    entity.HasMany(e => e.Gears)
                        .WithOne(p => p.Client)
                        .HasForeignKey(p => p.ClientId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

                    entity.HasMany(e => e.ClientInsurances)
                        .WithOne(p => p.Client)
                        .HasForeignKey(p => p.ClientId)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity.HasMany(e => e.ConflictInvolvements)
                        .WithOne(p => p.Client)
                        .HasForeignKey(p => p.ClientId)
                        .OnDelete(DeleteBehavior.Restrict);
                }
            );

            modelBuilder.Entity<Director>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.HasMany(e => e.InsuranceAgents)
                        .WithOne(p => p.Director)
                        .HasForeignKey(e => e.DirectorId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

                    entity.HasMany(e => e.InsuranceOffers)
                        .WithOne(p => p.Director)
                        .HasForeignKey(e => e.DirectorId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

                    entity.HasMany(e => e.Conflicts)
                        .WithOne(p => p.Director)
                        .HasForeignKey(p => p.DirectorId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);
                }
            );

            modelBuilder.Entity<ClientConnection>(entity =>
                {
                    entity.HasKey(e => e.Id);
                }
            );

            modelBuilder.Entity<Gear>(entity =>
                {
                    entity.HasKey(e => e.Id);
                }
            );

            modelBuilder.Entity<BackgroundInfo>(entity =>
                {
                    entity.HasKey(e => e.Id);
                }
            );

            modelBuilder.Entity<ClientInsurance>(entity =>
                {
                    entity.HasKey(e => e.Id);
                }
            );

            modelBuilder.Entity<InsuranceOffer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.ClientInsurances)
                    .WithOne(p => p.InsuranceOffer)
                    .HasForeignKey(p => p.InsuranceOfferId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            }
                );

            modelBuilder.Entity<Conflict>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.HasMany(e => e.ConflictInvolvements)
                        .WithOne(p => p.Conflict)
                        .HasForeignKey(p => p.ConflictId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);
                }
            );

            modelBuilder.Entity<ConflictInvolvement>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.HasMany(e => e.ConflictRecords)
                        .WithOne(p => p.ConflictInvolvement)
                        .HasForeignKey(p => p.ConflictInvolvementId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);
                }
            );

            modelBuilder.Entity<ConflictRecord>(entity =>
                {
                    entity.HasKey(e => e.Id);
                }
            );

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}