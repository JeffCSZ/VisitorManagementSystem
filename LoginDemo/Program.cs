using LoginDemo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure to SQL Server Connection
builder.Services.AddDbContext<MyDbContext>(o => o.UseSqlServer
        (builder.Configuration.GetConnectionString("DefaultConnection")));
// Configure to Identity
builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<MyDbContext>();
    //.AddDefaultTokenProviders();


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
