using BillingSystemServer.Extension;
using BillingSystemServer.Middleware;
using BusinessAccessLayer.Services.Implement;
using BusinessAccessLayer.Services.Interface;
using CommanLayer.Constant;
using DataAccessLayer.ApplicationDbContext;
using DataAccessLayer.Repository.Implement;
using DataAccessLayer.Repository.Interface;
using EntitiesLayer.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//define validation
builder.Services.AddControllers()
     .ConfigureApiBehaviorOptions(options =>
     {
         options.SuppressModelStateInvalidFilter = true;
     });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//run with extension
builder.Services.ConnectDatabase(builder.Configuration);
builder.Services.ConfigAuthentication(builder.Configuration);
builder.Services.RegisterRepository();
builder.Services.RegisterService();
builder.Services.RegisterMiddelware();
builder.Services.ConfigCors();
builder.Services.RegisterFluentValidation();
builder.Services.RegisterMapper();
builder.Services.RegisterMail(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CorsName.Corsname);

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
