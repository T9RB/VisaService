using Api_Passport_and_Visa_Service;
using Api_Passport_and_Visa_Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Service>();
builder.Services.AddControllers().AddNewtonsoftJson();

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VisaDbContext>(options => options.UseNpgsql(conString));

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var dbCon = serviceScope.ServiceProvider.GetRequiredService<VisaDbContext>();
    await dbCon.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();