using AutoMapper;
using BillingSystemServer.Middleware;
using BillingSystemServer.ValidationFilter;
using BusinessAccessLayer.Profiles;
using BusinessAccessLayer.Services.Implement;
using BusinessAccessLayer.Services.Interface;
using CommanLayer.Constant;
using CommanLayer.Validation;
using DataAccessLayer.ApplicationDbContext;
using DataAccessLayer.Repository.Implement;
using DataAccessLayer.Repository.Interface;
using EntitiesLayer.DTOs.Request;
using EntitiesLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text;

namespace BillingSystemServer.Extension
{
    public static class ConfigureService
    {
        public static void ConnectDatabase(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString(DbNameConstant.DbConnect));
            });
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IJwtManageRepository,JwtManageRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        }

        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>(); 
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
        }

        public static void RegisterMiddelware(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
        }

        public static void RegisterMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile));
        }
        public static void RegisterMail(this IServiceCollection services,IConfiguration config)
        {
            services.Configure<MailSettingDTO>(config.GetSection("MailSettings"));
            services.AddScoped<IMailService,MailService>();
        }

        public static void RegisterFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LoginValidationRule>(ServiceLifetime.Scoped);
            services.AddScoped<ValidationModel>();
        }

        public static void ConfigAuthentication(this IServiceCollection services, IConfiguration config)
        {

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                            }
                        },
                    new List < string > ()
                    }
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidAudience = config["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context => 
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("IS_TOKEN_EXPIRED","true");
                            }
                            return Task.CompletedTask;  
                        }
                    };
                });
        }
        public static void ConfigCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy(name: CorsName.Corsname,
                    builder =>
                    {
                        builder.WithOrigins(CorsAllowsConstant.ServerUrl, CorsAllowsConstant.ClientUrl)
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

        }
    }
}
