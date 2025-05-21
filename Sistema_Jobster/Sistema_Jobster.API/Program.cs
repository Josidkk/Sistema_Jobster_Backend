using Microsoft.EntityFrameworkCore;
using Sistema_Jobster.API.Extensions;
using Sistema_Jobster.DataAccess.Context;
using Sistema_Jobster.DataAccess;
using Sistema_Jobster.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);



// Modificado
var connectionString = builder.Configuration.GetConnectionString("SistemaJobsterConn");

builder.Services.AddDbContext<db_ab9479_jobsterContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddHttpContextAccessor();
builder.Services.DataAccess(connectionString);
builder.Services.BusinessLogic();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("http://localhost:4200/", policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(typeof(MappingProfileExtensions));
});


// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

//app.UseCors("http://localhost:4200/");

app.Run();
