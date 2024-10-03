using MicroBook.Domain.Abstractions;
using MicroBook.PostgreSQL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MicroBook.PostgreSQL;

/// <summary>
/// Entry class for PostgreSQL database.
/// </summary>
public static class Entry
{
    /// <summary>
    /// Registers DbContext.
    /// </summary>
    /// <param name="services">Services to add to.</param>
    /// <param name="connectionString">Connection string for db.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    }

    /// <summary>
    /// Registers repositories.
    /// </summary>
    /// <param name="services">Services to add to.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepository, BooksRepository>();

        return services;
    }
}