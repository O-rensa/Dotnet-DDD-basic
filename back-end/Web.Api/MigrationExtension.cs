using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Web.Api
{
    public static class MigrationExtension
    {
        public static async Task InitializeMigration(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
        }
    }
}
