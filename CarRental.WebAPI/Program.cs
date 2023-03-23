using Autofac;
using Autofac.Extensions.DependencyInjection;
using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.Business.DependencyResolvers.Autofac;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete;
using CarRental.DataAccess.Concrete.EntityFramework.Contexts;
using CarRental.DataAccess.Concrete.EntityFramework.Repositories;
using CarRental.Entities.Concrete;
using CarRental.WebAPI.Helpers.Abstract;
using CarRental.WebAPI.Helpers.Concrete;
using Core.DependencyResolvers;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IImageHelper, ImageHelper>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
// Email Konfigurasyonu
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddDependencyResolvers(new CoreModule());


//builder.Services.AddDbContext<CarRentalContext>();

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IBrandService, BrandManager>();
//builder.Services.AddScoped<IBrandRepository, EfBrandRepository>();
//builder.Services.AddScoped<ICarService, CarManager>();
//builder.Services.AddScoped<ICarRepository, EfCarRepository>();
//builder.Services.AddScoped<IColorService, ColorManager>();
//builder.Services.AddScoped<IColorRepository, EfColorRepository>();
//builder.Services.AddScoped<ICustomerService, CustomerManager>();
//builder.Services.AddScoped<ICustomerRepository, EfCustomerRepository>();
//builder.Services.AddScoped<IRentalService, RentalManager>();
//builder.Services.AddScoped<IRentalRepository, EfRentalRepository>();
//builder.Services.AddScoped<IUserService, UserManager>();
//builder.Services.AddScoped<IUserRepository, EfUserRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4201")
    .AllowAnyHeader();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
