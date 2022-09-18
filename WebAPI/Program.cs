using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//WebApi'nin kendi IoC Yapılandırmasını Kullanmak Icin
//builder.Services.AddSingleton<ICarService, CarManager>(); 
//builder.Services.AddSingleton<ICarDal, EFCarDal>();
//builder.Services.AddSingleton<IBrandService, BrandManager>();
//builder.Services.AddSingleton<IBrandDal, EFBrandDal>();
//builder.Services.AddSingleton<IColorService, ColorManager>();
//builder.Services.AddSingleton<IColorDal, EFColorDal>();
//builder.Services.AddSingleton<ICustomerService, CustomerManager>();
//builder.Services.AddSingleton<ICustomerDal, EFCustomerDal>();
//builder.Services.AddSingleton<IUserService, UserManager>();
//builder.Services.AddSingleton<IUserDal, EfUserDal>();
//builder.Services.AddSingleton<IRentalService, RentalManager>();
//builder.Services.AddSingleton<IRentalDal, EFRentalDal>();


//Autofac IoC Yapılandırmasını Kullanmak Icin(.Net 6 Autofac Configuration)
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
       .ConfigureContainer<ContainerBuilder>(builder =>
       {
           builder.RegisterModule(new AutofacBusinessModule());
       });

//Jwt
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

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
ServiceTool.Create(builder.Services);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
