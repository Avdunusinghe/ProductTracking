using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProductTracking.Api.Infrastructure;
using ProductTracking.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCustomeDbContext(builder.Configuration);
builder.Services.EnableCors(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new ApplicationModule());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();



public static class CustomerMiddleWareMethods
{
    public static IServiceCollection AddCustomeDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkSqlServer().AddDbContext<ProductTrackingDbContext>(options =>
        {
            options.UseLazyLoadingProxies().UseSqlServer(configuration["ProductTrackingDbConnectionString"], 
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            });


        });

        return services;
    }

    public static IServiceCollection EnableCors(this IServiceCollection services, IConfiguration configuration)
    {

        var allowedOrigins = new List<string>();
        var allowOrigins = configuration["AllowedOrigins"].Split(",");

        services.AddCors(options =>
        {
            options.AddPolicy(name: "CorsPolicy",
                      builder => builder.WithOrigins(allowOrigins)
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials());
        });

        return services;
    }
}