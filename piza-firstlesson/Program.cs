using myInterfaces;
using myServices;
using myModels;
using fileService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using piza_firstlesson.Extensions;
using piza_firstlesson.Middlewares;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IPizza, PizzaService>();
builder.Services.AddSingleton<IOrder, OrderService>();
builder.Services.AddScoped<IWorker, WorkerService>();
builder.Services.AddSingleton<IfileService<string>, ReadAndWrite<string> >();
builder.Services.AddSingleton<IfileService<Worker>, ReadAndWrite<Worker> >();
builder.Services.AddSingleton<IfileService<Pizza>, ReadAndWrite<Pizza> >();
builder.Services.AddScoped<Iidentity , IdentityService>();

builder.Services
        .AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.TokenValidationParameters = IdentityService.GetTokenValidationParameters();
        });

builder.Services.AddAuthorization(cfg =>
        {
            cfg.AddPolicy("Admin", policy => policy.RequireClaim("UserType", "Admin"));
            cfg.AddPolicy("SuperWorker", policy => policy.RequireClaim("UserType", "SuperWorker", "Admin"));
        });

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
        {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PIZZA", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        { new OpenApiSecurityScheme
                {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                },
            new string[] {}
        }
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseStaticFiles();
    app.UseDefaultFiles();
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseActionLog();

app.Run();
