using CompanyManagement.BUSINESS.Abstract;
using CompanyManagement.BUSINESS.Concrete;
using CompanyManagement.REPOSITORIES.Abstract;
using CompanyManagement.REPOSITORIES.Concrete;
using CompanyManagement.REPOSITORIES.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompanyManagement.API", Version = "v1" });
});
builder.Services.AddDbContext<CompanyManagerDBContext>(options =>
{
    options.UseSqlServer("Server=LAPTOP-FA6RBVRG; Database=CompanyManagmentEnocaDb; Uid=sa; Pwd=1234;");
});

builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompanyManagement.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
