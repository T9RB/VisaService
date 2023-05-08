using Api_Passport_and_Visa_Service;
using Api_Passport_and_Visa_Service.Authentication;
using Api_Passport_and_Visa_Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Key Auth", Version = "v1" });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "ApiKey must appear in header",
        Type = SecuritySchemeType.ApiKey,
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        { key, new List<string>() }
    };
    c.AddSecurityRequirement(requirement);
});

builder.Services.AddScoped<Service>();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<ApiKeyAuthFilter>();

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VisaDbContext>(options => options.UseNpgsql(conString));

var app = builder.Build();

// using (var serviceScope = app.Services.CreateScope())
// {
//     var dbCon = serviceScope.ServiceProvider.GetRequiredService<VisaDbContext>();
//     await dbCon.Database.MigrateAsync();
// }

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