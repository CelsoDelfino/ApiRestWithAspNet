using Microsoft.EntityFrameworkCore;
using RestWithAspNet.Data;
using RestWithAspNet.Business;
using RestWithAspNet.Business.Implementations;
using RestWithAspNet.Repository;
using RestWithAspNet.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var mySqlConnection = builder.Configuration["ConnectionStrings:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

//Versioning API
builder.Services.AddApiVersioning();

builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

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

app.Run();
