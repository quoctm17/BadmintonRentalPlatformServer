using Microsoft.EntityFrameworkCore;
using System.Data;
using BusinessObjects;
using Microsoft.Extensions.Configuration;
namespace DataAccessObject
{
    public class AppDbContext : DbContext
    {
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
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
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config.GetConnectionString("DefaultConnectionString");
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoleEntity>()
                .HasKey(ur => new { ur.Id, ur.RoleId });

            modelBuilder.Entity<UserRoleEntity>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.Id);

            modelBuilder.Entity<UserRoleEntity>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<NotificationEntity>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<BookingReservationEntity>()
                .HasOne(br => br.User)
                .WithMany(u => u.BookingReservations)
                .HasForeignKey(br => br.UserId);

            modelBuilder.Entity<BookingDetailEntity>()
                .HasOne(bd => bd.BookingReservation)
                .WithMany(br => br.BookingDetails)
                .HasForeignKey(bd => bd.BookingId);

            modelBuilder.Entity<BookingDetailEntity>()
                .HasOne(bd => bd.CourtSlot)
                .WithMany(cs => cs.BookingDetails)
                .HasForeignKey(bd => bd.CourtSlotId);

            modelBuilder.Entity<CourtImageEntity>()
                .HasOne(ci => ci.BadmintonCourt)
                .WithMany(bc => bc.CourtImages)
                .HasForeignKey(ci => ci.BadmintonCourtId);

            modelBuilder.Entity<CourtEntity>()
                .HasOne(c => c.BadmintonCourt)
                .WithMany(bc => bc.Courts)
                .HasForeignKey(c => c.BadmintonCourtId);

            modelBuilder.Entity<CourtEntity>()
                .HasOne(c => c.TypeOfCourt)
                .WithMany(tc => tc.Courts)
                .HasForeignKey(c => c.TypeOfCourtId);

            modelBuilder.Entity<CourtSlotEntity>()
                .HasOne(cs => cs.Court)
                .WithMany(c => c.CourtSlots)
                .HasForeignKey(cs => cs.CourtNumberId);

            modelBuilder.Entity<BadmintonCourtEntity>()
               .HasOne(bc => bc.CourtOwner)
               .WithMany(u => u.BadmintonCourts)
               .HasForeignKey(bc => bc.CourtOwnerId);
        }

    }

}
