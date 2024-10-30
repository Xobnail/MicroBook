using MassTransit;
using MicroBook.Application;
using MicroBook.Host.Migrations;
using Microsoft.AspNetCore.Authentication.Certificate;

namespace MicroBook;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add distributed cache
        builder.Services.AddStackExchangeRedisCache(redisOptions =>
        {
            var connectionString = builder.Configuration.GetConnectionString("Redis");
            redisOptions.Configuration = connectionString;
        });

        // Add message broker
        builder.Services.AddMassTransit(configure =>
        {
            configure.AddConsumer<BooksConsumer>();

            configure.SetKebabCaseEndpointNameFormatter();

            configure.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(builder.Configuration["RabbitMQ:Host"]!), h =>
                {
                    h.Username(builder.Configuration["RabbitMQ:Username"]!);
                    h.Password(builder.Configuration["RabbitMQ:Password"]!);
                });

                cfg.ReceiveEndpoint(builder.Configuration["RabbitMQ:Queues:Books"]!, e =>
                {
                    e.Bind(builder.Configuration["RabbitMQ:Exchanges:Books"]!);

                    e.ConfigureConsumer<BooksConsumer>(context);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();

        // Add application layer
        builder.Services.AddApplication(builder.Configuration.GetConnectionString("DefaultConnection")!);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.ApplyMigrations();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllers();

        app.Run();
    }
}
