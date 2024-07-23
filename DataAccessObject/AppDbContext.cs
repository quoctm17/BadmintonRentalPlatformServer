using Microsoft.EntityFrameworkCore;
using System.Data;
using BusinessObjects;
using Microsoft.Extensions.Configuration;
namespace DataAccessObject
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<NotificationEntity> Notifications { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<BookingReservationEntity> BookingReservations { get; set; }
        public DbSet<BookingDetailEntity> BookingDetails { get; set; }
        public DbSet<CourtImageEntity> CourtImages { get; set; }
        public DbSet<BadmintonCourtEntity> BadmintonCourts { get; set; }
        public DbSet<TypeOfCourtEntity> TypeOfCourts { get; set; }
        public DbSet<CourtEntity> Courts { get; set; }
        public DbSet<CourtSlotEntity> CourtSlots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(GetConnectionString());

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return configuration.GetConnectionString("DefaultConnectionString") ?? "";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasIndex(p => p.Email).IsUnique();

            #region Entity Relation
            modelBuilder.Entity<UserEntity>()
               .HasOne(p => p.Role)
               .WithMany(d => d.Users)
               .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<NotificationEntity>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingReservationEntity>()
                .HasOne(br => br.User)
                .WithMany(u => u.BookingReservations)
                .HasForeignKey(br => br.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<BookingReservationEntity>()
                .HasOne(br => br.BadmintonCourt)
                .WithMany(bc => bc.BookingReservations)
                .HasForeignKey(br => br.BadmintonCourtId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingDetailEntity>()
                .HasOne(bd => bd.BookingReservation)
                .WithMany(br => br.BookingDetails)
                .HasForeignKey(bd => bd.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingDetailEntity>()
                .HasOne(bd => bd.CourtEntity)
                .WithMany(c => c.BookingDetailEntities)
                .HasForeignKey(bd => bd.CourtId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CourtSlotEntity>()
                .HasOne(cs => cs.BookingDetail)
                .WithMany(bd => bd.CourtSlots)
                .HasForeignKey(cs => cs.BookingDetailId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourtImageEntity>()
                .HasOne(ci => ci.BadmintonCourt)
                .WithMany(bc => bc.CourtImages)
                .HasForeignKey(ci => ci.BadmintonCourtId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourtEntity>()
                .HasOne(c => c.BadmintonCourt)
                .WithMany(bc => bc.Courts)
                .HasForeignKey(c => c.BadmintonCourtId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourtEntity>()
                .HasOne(c => c.TypeOfCourt)
                .WithMany(tc => tc.Courts)
                .HasForeignKey(c => c.TypeOfCourtId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BadmintonCourtEntity>()
               .HasOne(bc => bc.CourtOwner)
               .WithMany(u => u.BadmintonCourts)
               .HasForeignKey(bc => bc.CourtOwnerId)
               .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }

    }

}
