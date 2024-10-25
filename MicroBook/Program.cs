using MassTransit;
using MicroBook.Application;
using Microsoft.AspNetCore.Authentication.Certificate;

namespace MicroBook;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddStackExchangeRedisCache(redisOptions =>
        {
            var connectionString = builder.Configuration.GetConnectionString("Redis");
            redisOptions.Configuration = connectionString;
        });

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

        builder.Services.AddApplication(builder.Configuration.GetConnectionString("DefaultConnection")!);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllers();

        app.Run();
    }
}
