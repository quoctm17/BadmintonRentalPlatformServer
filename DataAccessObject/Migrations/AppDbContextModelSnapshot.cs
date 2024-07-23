﻿// <auto-generated />
using System;
using DataAccessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessObject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObjects.BadmintonCourtEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourtNumber")
                        .HasColumnType("int");

                    b.Property<int>("CourtOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("NumberOfCourt")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CourtOwnerId");

                    b.ToTable("BadmintonCourts");
                });

            modelBuilder.Entity("BusinessObjects.BookingDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("CourtId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("CourtId");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("BusinessObjects.BookingReservationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BadmintonCourtId")
                        .HasColumnType("int");

                    b.Property<string>("BookingStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BadmintonCourtId");

                    b.HasIndex("UserId");

                    b.ToTable("BookingReservations");
                });

            modelBuilder.Entity("BusinessObjects.CourtEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BadmintonCourtId")
                        .HasColumnType("int");

                    b.Property<string>("CourtCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("TypeOfCourtId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BadmintonCourtId");

                    b.HasIndex("TypeOfCourtId");

                    b.ToTable("Courts");
                });

            modelBuilder.Entity("BusinessObjects.CourtImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BadmintonCourtId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBackground")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMainCarousel")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BadmintonCourtId");

                    b.ToTable("CourtImages");
                });

            modelBuilder.Entity("BusinessObjects.CourtSlotEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingDetailId")
                        .HasColumnType("int");

                    b.Property<int>("CourtId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("BookingDetailId");

                    b.HasIndex("CourtId");

                    b.ToTable("CourtSlots");
                });

            modelBuilder.Entity("BusinessObjects.NotificationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NotificationContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("BusinessObjects.PaymentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BusinessObjects.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BusinessObjects.TransactionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingReservationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("GrossAmount")
                        .HasColumnType("real");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingReservationId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BusinessObjects.TypeOfCourtEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfCourts");
                });

            modelBuilder.Entity("BusinessObjects.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordEncrypt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BusinessObjects.BadmintonCourtEntity", b =>
                {
                    b.HasOne("BusinessObjects.UserEntity", "CourtOwner")
                        .WithMany("BadmintonCourts")
                        .HasForeignKey("CourtOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourtOwner");
                });

            modelBuilder.Entity("BusinessObjects.BookingDetailEntity", b =>
                {
                    b.HasOne("BusinessObjects.BookingReservationEntity", "BookingReservation")
                        .WithMany("BookingDetails")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.CourtEntity", "CourtEntity")
                        .WithMany("BookingDetailEntities")
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BookingReservation");

                    b.Navigation("CourtEntity");
                });

            modelBuilder.Entity("BusinessObjects.BookingReservationEntity", b =>
                {
                    b.HasOne("BusinessObjects.BadmintonCourtEntity", "BadmintonCourt")
                        .WithMany("BookingReservations")
                        .HasForeignKey("BadmintonCourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.UserEntity", "User")
                        .WithMany("BookingReservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BadmintonCourt");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusinessObjects.CourtEntity", b =>
                {
                    b.HasOne("BusinessObjects.BadmintonCourtEntity", "BadmintonCourt")
                        .WithMany("Courts")
                        .HasForeignKey("BadmintonCourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.TypeOfCourtEntity", "TypeOfCourt")
                        .WithMany("Courts")
                        .HasForeignKey("TypeOfCourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BadmintonCourt");

                    b.Navigation("TypeOfCourt");
                });

            modelBuilder.Entity("BusinessObjects.CourtImageEntity", b =>
                {
                    b.HasOne("BusinessObjects.BadmintonCourtEntity", "BadmintonCourt")
                        .WithMany("CourtImages")
                        .HasForeignKey("BadmintonCourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BadmintonCourt");
                });

            modelBuilder.Entity("BusinessObjects.CourtSlotEntity", b =>
                {
                    b.HasOne("BusinessObjects.BookingDetailEntity", "BookingDetail")
                        .WithMany("CourtSlots")
                        .HasForeignKey("BookingDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.CourtEntity", "CourtEntity")
                        .WithMany("CourtSlots")
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BookingDetail");

                    b.Navigation("CourtEntity");
                });

            modelBuilder.Entity("BusinessObjects.NotificationEntity", b =>
                {
                    b.HasOne("BusinessObjects.UserEntity", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusinessObjects.TransactionEntity", b =>
                {
                    b.HasOne("BusinessObjects.BookingReservationEntity", "BookingReservation")
                        .WithMany("Transactions")
                        .HasForeignKey("BookingReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.PaymentEntity", "Payment")
                        .WithMany("Transactions")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BookingReservation");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("BusinessObjects.UserEntity", b =>
                {
                    b.HasOne("BusinessObjects.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BusinessObjects.BadmintonCourtEntity", b =>
                {
                    b.Navigation("BookingReservations");

                    b.Navigation("CourtImages");

                    b.Navigation("Courts");
                });

            modelBuilder.Entity("BusinessObjects.BookingDetailEntity", b =>
                {
                    b.Navigation("CourtSlots");
                });

            modelBuilder.Entity("BusinessObjects.BookingReservationEntity", b =>
                {
                    b.Navigation("BookingDetails");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BusinessObjects.CourtEntity", b =>
                {
                    b.Navigation("BookingDetailEntities");

                    b.Navigation("CourtSlots");
                });

            modelBuilder.Entity("BusinessObjects.PaymentEntity", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BusinessObjects.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BusinessObjects.TypeOfCourtEntity", b =>
                {
                    b.Navigation("Courts");
                });

            modelBuilder.Entity("BusinessObjects.UserEntity", b =>
                {
                    b.Navigation("BadmintonCourts");

                    b.Navigation("BookingReservations");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
