using MassTransit;
using MicroBook.Application.Repositories;
using MicroBook.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MicroBook.Application;

/// <summary>
/// Entry class for Application layer.
/// </summary>
public static class Entry
{
    /// <summary>
    /// Registers services for application layer.
    /// </summary>
    /// <param name="services">Services to add to.</param>
    /// <param name="connectionString">Connection string for db.</param>
    /// <returns>Same service collection.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IBooksRepository, BooksRepository>();

        return services;
    }
}