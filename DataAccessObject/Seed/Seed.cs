using BusinessObjects;
using BusinessObjects.Enums;
using BusinessObjects.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace DataAccessObject.Seed
{
    public class Seed
    {
        public static async Task SeedBadmintonCourts(AppDbContext _context)
        {
            if (!await _context.BadmintonCourts.AnyAsync())
            {
                var courtData = await File.ReadAllTextAsync("../DataAccessObject/Seed/BadmintonCourtSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var courts = JsonSerializer.Deserialize<List<BadmintonCourtEntity>>(courtData, jsonOptions);

                foreach (var court in courts)
                {
                    await _context.BadmintonCourts.AddAsync(court);
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedCourtImages(AppDbContext _context)
        {
            if (!await _context.CourtImages.AnyAsync())
            {
                var imageData = await File.ReadAllTextAsync("../DataAccessObject/Seed/CourtImageSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var images = JsonSerializer.Deserialize<List<CourtImageEntity>>(imageData, jsonOptions);

                foreach (var image in images)
                {
                    await _context.CourtImages.AddAsync(image);
                }

                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedTypeOfCourts(AppDbContext _context)
        {
            if (!await _context.TypeOfCourts.AnyAsync())
            {
                var typeData = await File.ReadAllTextAsync("../DataAccessObject/Seed/TypeOfCourtSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var types = JsonSerializer.Deserialize<List<TypeOfCourtEntity>>(typeData, jsonOptions);

                foreach (var type in types)
                {
                    await _context.TypeOfCourts.AddAsync(type);
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedCourts(AppDbContext _context)
        {
            if (!await _context.Courts.AnyAsync())
            {
                var courtData = await File.ReadAllTextAsync("../DataAccessObject/Seed/CourtSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var courts = JsonSerializer.Deserialize<List<CourtEntity>>(courtData, jsonOptions);

                foreach (var court in courts)
                {
                    await _context.Courts.AddAsync(court);
                }

                await _context.SaveChangesAsync();
            }
        }


        public static async Task SeedUsers(AppDbContext _context)
        {
            if (!await _context.Users.AnyAsync())
            {
                var userData = await File.ReadAllTextAsync("../DataAccessObject/Seed/UserSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var users = JsonSerializer.Deserialize<List<UserEntity>>(userData, jsonOptions);

                foreach (var user in users)
                {
                    await _context.Users.AddAsync(user);
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedPayments(AppDbContext _context)
        {
            if (!await _context.Payments.AnyAsync())
            {
                var paymentData = await File.ReadAllTextAsync("../DataAccessObject/Seed/PaymentSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var payments = JsonSerializer.Deserialize<List<PaymentEntity>>(paymentData, jsonOptions);

                foreach (var payment in payments)
                {
                    await _context.Payments.AddAsync(payment);
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedRoles(AppDbContext _context)
        {
            if (!await _context.Roles.AnyAsync())
            {
                var roleData = await File.ReadAllTextAsync("../DataAccessObject/Seed/RoleSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var roles = JsonSerializer.Deserialize<List<RoleEntity>>(roleData, jsonOptions);

                foreach (var role in roles)
                {
                    await _context.Roles.AddAsync(role);
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedNotifications(AppDbContext _context)
        {
            if (!await _context.Notifications.AnyAsync())
            {
                var notificationData = await File.ReadAllTextAsync("../DataAccessObject/Seed/NotificationSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var notifications = JsonSerializer.Deserialize<List<NotificationEntity>>(notificationData, jsonOptions);

                foreach (var notification in notifications)
                {
                    await _context.Notifications.AddAsync(notification);
                }

                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedBookings(AppDbContext _context)
        {
            if (!await _context.BookingReservations.AnyAsync())
            {
                var user = await _context.Users.FirstOrDefaultAsync();
                var court = await _context.BadmintonCourts.Include(bc => bc.Courts).FirstOrDefaultAsync();

                if (user != null && court != null)
                {
                    var dates = new List<DateTime> { DateTime.Now, DateTime.Now.AddDays(1) };
                    var courtDetails = court.Courts.Take(2).ToList(); // Lấy 2 Court đầu tiên

                    string[] bookingStatuses = { "PAYING", "BOOKED", "USED", "EXPIRED", "CANCELLED" };
                    TransactionStatusEnum[] transactionStatuses = { TransactionStatusEnum.FAIL, TransactionStatusEnum.PENDING, TransactionStatusEnum.COMPLETE, TransactionStatusEnum.CANCEL };
                    string[] paymentMethods = { "Cash", "Bank Transfer" };
                    TransactionTypeEnum[] transactionTypes = { TransactionTypeEnum.Income, TransactionTypeEnum.Expense };

                    for (int j = 0; j < bookingStatuses.Length; j++) // Tạo 5 BookingReservation với các trạng thái khác nhau
                    {
                        var bookingReservation = new BookingReservationEntity
                        {
                            UserId = user.Id,
                            BadmintonCourtId = court.Id,
                            CreateAt = DateTime.Now,
                            BookingStatus = bookingStatuses[j],
                            TotalPrice = 0,
                            Notes = "Seed data booking",
                            Transactions = new List<TransactionEntity>(),
                            BookingDetails = new List<BookingDetailEntity>()
                        };

                        foreach (var date in dates)
                        {
                            foreach (var courtDetail in courtDetails)
                            {
                                var courtSlots = new List<CourtSlotEntity>();

                                for (int i = 0; i < 1; i++) // Tạo 1 TimeSlot cho mỗi BookingDetail
                                {
                                    var startTime = new TimeSpan(7 + i * 2, 0, 0); // Mỗi slot cách nhau 2 giờ
                                    var endTime = startTime.Add(new TimeSpan(0, 30, 0)); // Thêm 30 phút vào StartTime

                                    courtSlots.Add(new CourtSlotEntity
                                    {
                                        StartTime = startTime,
                                        EndTime = endTime,
                                        DateTime = date,
                                        CourtSlotStatus = (int) CourtSlotStatusEnum.Booked,
                                        CourtId = courtDetail.Id // Cập nhật CourtId cho CourtSlotEntity
                                    });
                                }

                                var bookingDetail = new BookingDetailEntity
                                {
                                    CourtId = courtDetail.Id,
                                    CourtEntity = courtDetail,
                                    Price = courtDetail.Price * courtSlots.Count,
                                    CourtSlots = courtSlots
                                };

                                bookingReservation.BookingDetails.Add(bookingDetail);
                                bookingReservation.TotalPrice += bookingDetail.Price;
                            }
                        }

                        await _context.BookingReservations.AddAsync(bookingReservation);
                        await _context.SaveChangesAsync();

                        // Seed Transactions
                        var randomTransactionStatus = transactionStatuses[j % transactionStatuses.Length].GetDescriptionFromEnum();
                        var randomPaymentMethod = paymentMethods[j % paymentMethods.Length];
                        var randomTransactionType = transactionTypes[j % transactionTypes.Length];

                        var transaction = new TransactionEntity
                        {
                            GrossAmount = bookingReservation.TotalPrice,
                            Type = randomTransactionType,
                            CreateAt = DateTime.Now,
                            Status = randomTransactionStatus,
                            PaymentId = (await _context.Payments.FirstOrDefaultAsync(p => p.PaymentMethod == randomPaymentMethod)).Id,
                            BookingReservationId = bookingReservation.Id // Liên kết với BookingReservation
                        };

                        await _context.Transactions.AddAsync(transaction);
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }



    }
}
