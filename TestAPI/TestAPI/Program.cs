using System;
using TestAPI.Helpers;
using TestAPI.Models;
using TestAPI.Services;
using WebApi.Authorization;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
// configure strongly typed settings object

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
// configure DI for application services
services.AddScoped<IJwtUtils, JwtUtils>();

services.AddScoped<IAccountService, AccountService>();
services.AddScoped<IEmailService, EmailService >();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


services.AddDbContext<APIContext>();


var app = builder.Build();


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
