using System.Text.Json;
using efcorealloperations.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ILoggerFactory loggerFactory = LoggerFactory.Create(logging => {
    logging.AddConsole();
    logging.AddDebug();
});

var logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("---> Application start");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? "");

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions{
    ResponseWriter = async (context, report)=>{
        context.Response.ContentType= "application/json";
        var result = JsonSerializer.Serialize(new {
            status = report.Status.ToString(),
            error = report.Entries.Select(e=>new{Key = e.Key, value = e.Value.Status.ToString()})
        });

        await context.Response.WriteAsync(result);
    }
});

app.MapControllers();

app.UseHttpsRedirection();

ApplyMigrartion();

app.Run();


void ApplyMigrartion()
{
    using var scope = app.Services.CreateScope();
    var requestedService = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if(requestedService.Database.GetPendingMigrations().Count()>0)
    {
        requestedService.Database.Migrate();
    }

}

