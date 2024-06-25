using BusinessObjects;
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
                var courtData = await File.ReadAllTextAsync("../DataAccess/Seed/BadmintonCourtSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var courts = JsonSerializer.Deserialize<List<BadmintonCourtEntity>>(courtData, jsonOptions);

                foreach (var court in courts)
                {
                    await _context.BadmintonCourts.AddAsync(court);
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedTypeOfCourts(AppDbContext _context)
        {
            if (!await _context.TypeOfCourts.AnyAsync())
            {
                var typeData = await File.ReadAllTextAsync("../DataAccess/Seed/TypeOfCourtSeed.json");
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
                var courtData = await File.ReadAllTextAsync("../DataAccess/Seed/CourtSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var courts = JsonSerializer.Deserialize<List<CourtEntity>>(courtData, jsonOptions);

                foreach (var court in courts)
                {
                    await _context.Courts.AddAsync(court);
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedSlots(AppDbContext _context)
        {
            if (!await _context.Slots.AnyAsync())
            {
                var slotData = await File.ReadAllTextAsync("../DataAccess/Seed/SlotSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var slots = JsonSerializer.Deserialize<List<SlotEntity>>(slotData, jsonOptions);

                foreach (var slot in slots)
                {
                    await _context.Slots.AddAsync(slot);
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedCourtSlots(AppDbContext _context)
        {
            if (!await _context.CourtSlots.AnyAsync())
            {
                var courts = await _context.Courts.ToListAsync();
                var slots = await _context.Slots.ToListAsync();

                foreach (var court in courts)
                {
                    foreach (var slot in slots)
                    {
                        var courtSlot = new CourtSlotEntity
                        {
                            CourtNumberId = court.Id,
                            SlotId = slot.Id,
                            Price = 100 // Set your desired price
                        };
                        await _context.CourtSlots.AddAsync(courtSlot);
                    }
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedUsers(AppDbContext _context)
        {
            if (!await _context.Users.AnyAsync())
            {
                var userData = await File.ReadAllTextAsync("../DataAccess/Seed/UserSeed.json");
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
                var paymentData = await File.ReadAllTextAsync("../DataAccess/Seed/PaymentSeed.json");
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
                var roleData = await File.ReadAllTextAsync("../DataAccess/Seed/RoleSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var roles = JsonSerializer.Deserialize<List<RoleEntity>>(roleData, jsonOptions);

                foreach (var role in roles)
                {
                    await _context.Roles.AddAsync(role);
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedUserRoles(AppDbContext _context)
        {
            if (!await _context.UserRoles.AnyAsync())
            {
                var userRoleData = await File.ReadAllTextAsync("../DataAccess/Seed/UserRoleSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var userRoles = JsonSerializer.Deserialize<List<UserRoleEntity>>(userRoleData, jsonOptions);

                foreach (var userRole in userRoles)
                {
                    await _context.UserRoles.AddAsync(userRole);
                }

                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedNotifications(AppDbContext _context)
        {
            if (!await _context.Notifications.AnyAsync())
            {
                var notificationData = await File.ReadAllTextAsync("../DataAccess/Seed/NotificationSeed.json");
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var notifications = JsonSerializer.Deserialize<List<NotificationEntity>>(notificationData, jsonOptions);

                foreach (var notification in notifications)
                {
                    await _context.Notifications.AddAsync(notification);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
