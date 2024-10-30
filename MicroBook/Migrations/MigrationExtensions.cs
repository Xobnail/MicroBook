using MicroBook.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace MicroBook.Host.Migrations;

/// <summary>
/// Contains extension methods for migrations.
/// </summary>
public static class MigrationExtensions
{
    /// <summary>
    /// Applies migrations.
    /// </summary>
    /// <param name="app">Application builder.</param>
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        
        using AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Database.Migrate();
    }
}
