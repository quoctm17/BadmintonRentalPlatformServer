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
    }
}
