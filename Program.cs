using CrudOperation.Data;
using CrudOperation.DI;
using CrudOperation.Repository.Interfaces;
using CrudOperation.Repository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//ConnectionString
builder.Services.AddDbContext<EmployeeDbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmpConn")));

//Register your Service
builder.Services.AddDependency();

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
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
