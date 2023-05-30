using DanceSchool.Entities;

namespace DanceSchool.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DanceSchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new[]
            {
                new User { Email = "john@example.com", PasswordHash = "password", FirstName = "pavol", LastName = "Peter" },
                new User { Email = "jane@example.com", PasswordHash = "password", FirstName = "peter", LastName = "Pavol" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
