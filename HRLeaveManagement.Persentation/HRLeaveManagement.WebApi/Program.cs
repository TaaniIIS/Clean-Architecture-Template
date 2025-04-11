using HRLeaveManagement.Application.Extensions;
using HRLeaveManagement.Infrastructure;
using HRLeaveManagement.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));//

builder.Services.AddIdentityApiEndpoints<IdentityUser>().
    AddRoles<IdentityRole>().
    AddEntityFrameworkStores<ApplicationDbContext>();//
builder.Services.AddControllers();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// application layer
builder.Services.AddApplicationServices();

// infrastructure layer
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();
app.MapIdentityApi<IdentityUser>(); // me


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
